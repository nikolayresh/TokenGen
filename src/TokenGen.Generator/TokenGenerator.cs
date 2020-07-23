﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.Extensions.Options;
using TokenGen.Generator.Rules;

namespace TokenGen.Generator
{
    /// <summary>
    /// Generator engine
    /// </summary>
    public static class TokenGenerator
    {
        /// <summary>
        /// Generates a new random token using specified options
        /// </summary>
        public static IRandomToken Generate(IOptions<TokenOptions> iOptions)
        {
            var options = ValidateOptions(iOptions);

            string tokenPayload;

            var token = new StringBuilder();
            var rules = ResolveRules(options);
            var charSets = CharSetManager.BuildCharSetsList(options.CharSets);
            var reRun = false;

            do
            {
                token.Clear();

                AppendConsecutivePart(token, charSets);
                AppendNonConsecutivePart(token, charSets, options.TokenLength - charSets.Count);
                tokenPayload = Randomizer.Shuffle(token.ToString());

                if (rules.Count > 0)
                {
                    ITokenRule failedRule;
                    reRun = !RunRules(rules, tokenPayload, out failedRule);

                    if (reRun && failedRule is IShuffleOnFail)
                    {
                        reRun = false;
                        tokenPayload = Randomizer.Shuffle(tokenPayload);

                        while (!failedRule.TryPass(tokenPayload))
                        {
                            tokenPayload = Randomizer.Shuffle(tokenPayload);
                        }
                    }
                }

            } while (reRun);

            return new RandomToken(tokenPayload, options);
        }

        private static bool RunRules(List<ITokenRule> rules, string token, out ITokenRule failedRule)
        {
            failedRule = default;

            foreach (var rule in rules)
            {
                if (!rule.TryPass(token))
                {
                    failedRule = rule;
                    return false;
                }
            }

            return true;
        }

        private static void AppendConsecutivePart(StringBuilder token, ImmutableList<char[]> charSets)
        {
            var charSelectors = Randomizer.NextIntegers(charSets.Count);

            for (var i = 0; i < charSets.Count; i++)
            {
                var set = charSets[i];
                token.Append( set[charSelectors[i] % set.Length] );
            }
        }

        private static void AppendNonConsecutivePart(StringBuilder token, ImmutableList<char[]> charSets, int length)
        {
            if (length == 0)
            {
                return;
            }

            var tuples = Randomizer.NextTuples(length);

            for (var i = 0; i < length; i++)
            {
                var (SetNumber, CharNumber) = tuples[i];
                var randomSet = charSets[SetNumber % charSets.Count];
                var randomChar = randomSet[CharNumber % randomSet.Length];

                token.Append(randomChar);
            }
        }

        private static TokenOptions ValidateOptions(IOptions<TokenOptions> iOptions)
        {
            if (iOptions is null)
            {
                throw new ArgumentNullException(nameof(iOptions));
            }

            var options = iOptions.Value;

            if (options is null)
            {
                throw new ArgumentNullException(nameof(iOptions.Value));
            }

            if (options.TokenLength <= 0)
            {
                throw new ArgumentException(
                    "Length of token must be a positive integer", 
                    nameof(iOptions.Value.TokenLength));
            }

            if (options.TokenLength < CharSetManager.GetSetsCount(options.CharSets))
            {
                throw new ArgumentException(
                    "Length of token must be greater or equal to count of character sets",
                    nameof(iOptions.Value.TokenLength));
            }

            return options;
        }

        private static List<ITokenRule> ResolveRules(TokenOptions options)
        {
            var rules = new List<ITokenRule>();

            if (options.RequiredUniqueness != null)
            {
                rules.Add(new TokenCharsUniquenessRule(options));
            }

            if (options.ExcludedAtStart != null)
            {
                rules.Add(new TokenNeverStartsWithRule(options));
            }

            if (options.ExcludedAtEnd != null)
            {
                rules.Add(new TokenNeverEndsWithRule(options));
            }

            return rules;
        }
    }
}
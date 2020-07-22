using System;
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

            do
            {
                token.Clear();

                AppendConsecutiveRange(token, charSets);

                var tuples = Randomizer.NextTuples(options.TokenLength - charSets.Count);
                if (tuples.Length > 0)
                {
                    AppendNonConsecutiveRange(token, tuples, charSets);
                }

                tokenPayload = Randomizer.Shuffle(token.ToString());

            } while (rules.Count > 0 && !rules.TrueForAll(x => x.TryPass(tokenPayload)));

            return new RandomToken(tokenPayload, options);
        }

        private static void AppendNonConsecutiveRange(StringBuilder token, Tuple<int, int>[] tuples, ImmutableList<char[]> charSets)
        {
            for (var i = 0; i < tuples.Length; i++)
            {
                var (SetNumber, CharNumber) = tuples[i];
                var randomSet = charSets[SetNumber % charSets.Count];
                var randomChar = randomSet[CharNumber % randomSet.Length];

                token.Append(randomChar);
            }
        }

        private static void AppendConsecutiveRange(StringBuilder token, ImmutableList<char[]> charSets)
        {
            for (var i = 0; i < charSets.Count; i++)
            {
                var set = charSets[i];
                token.Append(Randomizer.SelectRandomItem(set));
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

            if (options.UniqueChars != null)
            {
                rules.Add(new TokenUniquenessRule(options));
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
using System;
using System.Collections.Generic;
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

            var token = new StringBuilder();
            var rules = ResolveRules(options);
            var symbols = CharSet.GetTokenSymbols(options.SymbolFlags);
            string tokenPayload;

            do
            {
                token.Clear();
                var bytes = RngEngine.NextBytes(options.Length * sizeof(int));

                for (var i = 0; i < bytes.Length; i += sizeof(int))
                {
                    var number = BitConverter.ToInt32(bytes, i) & 0x7FFFFFFF;

                    token.Append(symbols[number % symbols.Length]);
                }

                tokenPayload = token.ToString();

            } while (rules.Count > 0 && !rules.TrueForAll(x => x.TryPass(tokenPayload)));

            return new RandomToken(tokenPayload, options);
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

            if (options.Length <= 0)
            {
                throw new ArgumentException(
                    "Length of token must be a positive integer",
                    nameof(iOptions.Value.Length));
            }

            if (options.UniqueChars != null && (options.UniqueChars < 0 || options.UniqueChars > options.Length))
            {
                throw new ArgumentException(
                    $"Count of unique symbols must be defined on range [0 - {options.Length}]",
                    nameof(iOptions.Value.UniqueChars));
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
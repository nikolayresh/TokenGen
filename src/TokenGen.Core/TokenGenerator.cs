using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Extensions.Options;
using TokenGen.Core.Rules;

namespace TokenGen.Core
{
    /// <summary>
    /// Generator engine 
    /// </summary>
    public static class TokenGenerator
    {
        /// <summary>
        /// Generates a new random token using specified options
        /// </summary>
        public static IToken Generate(IOptions<TokenOptions> iOptions)
        {
            if (iOptions is null)
            {
                throw new ArgumentNullException(nameof(iOptions));
            }

            if (iOptions.Value is null)
            {
                throw new ArgumentNullException(nameof(iOptions.Value));
            }

            var options = iOptions.Value;

            if (options.Length <= 0)
            {
                if (options.Length == -1)
                {
                    throw new ArgumentException(
                        "Length of token is not set",
                        nameof(iOptions.Value.Length));
                }

                throw new ArgumentException(
                    "Length of token must be a positive integer",
                    nameof(iOptions.Value.Length));
            }

            var token = new StringBuilder();
            var rules = ResolveRules(options);
            var symbols = SymbolSet.GetTokenSymbols(options.SymbolFlags);
            string tokenPayload = null;

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

            } while (rules.Count > 0 && !rules.TrueForAll(
                         x => x.TryPass(tokenPayload)));

            return new GeneratedToken(tokenPayload, options);
        }

        private static List<ITokenRule> ResolveRules(TokenOptions options)
        {
            var rules = new List<ITokenRule>();

            if (options.UniquenessRate > 0.0M)
            {
                rules.Add(new RequiredUniquenessRule(options));
            }

            return rules;
        }
    }
}

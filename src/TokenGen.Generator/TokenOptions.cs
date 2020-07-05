using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace TokenGen.Generator
{
    public sealed class TokenOptions : IOptions<TokenOptions>
    {
        private const decimal OptionalDistinctionRate = 0.0M;
        private const decimal MaxDistinctionRate = 100.0M;

        private int _length;
        private string _prefix;
        private string _postfix;
        private SymbolSet.Flags _sets;
        private decimal _distinctionRate;
        private HashSet<char> _excludedAtStart;
        private HashSet<char> _excludedAtEnd;

        internal string Prefix
        {
            get => _prefix;
        }

        internal string Postfix
        {
            get => _postfix;
        }

        /// <summary>
        ///     Gets length of a token to generate
        /// </summary>
        internal int Length
        {
            get => _length;
        }

        internal SymbolSet.Flags SymbolFlags => _sets;

        internal decimal DistinctionRate
        {
            get => _distinctionRate;
        }

        TokenOptions IOptions<TokenOptions>.Value
        {
            get
            {
                return this;
            }
        }
        
        public TokenOptions WithPrefix(string prefix)
        {
            _prefix = prefix;
            return this;
        }

        public TokenOptions WithPostfix(string postfix)
        {
            _postfix = postfix;
            return this;
        }

        /// <summary>
        ///     Sets desirable length of a random token to generate
        /// </summary>
        public TokenOptions WithLength(int length)
        {
            _length = length;
            return this;
        }

        public TokenOptions WithMaximalDistinction()
        {
            _distinctionRate = MaxDistinctionRate;
            return this;
        }

        public TokenOptions WithOptionalDistinction()
        {
            _distinctionRate = OptionalDistinctionRate;
            return this;
        }

        /// <summary>
        /// Includes digits into alphabet of token symbols
        /// </summary>
        public TokenOptions WithDigits()
        {
            _sets |= SymbolSet.Flags.Digits;
            return this;
        }

        public TokenOptions WithLowerLetters()
        {
            _sets |= SymbolSet.Flags.LowerCaseLetters;
            return this;
        }

        public TokenOptions WithUpperLetters()
        {
            _sets |= SymbolSet.Flags.UpperCaseLetters;
            return this;
        }

        public TokenOptions NeverStartsWith(char symbol)
        {
            var set = _excludedAtStart ??= new HashSet<char>();
            set.Add(symbol);
            return this;
        }

        public TokenOptions NeverStartsWith(IEnumerable<char> symbols)
        {
            if (symbols is null)
            {
                throw new ArgumentNullException(nameof(symbols));
            }

            var set = _excludedAtStart ??= new HashSet<char>();

            foreach (var symbol in symbols)
            {
                set.Add(symbol);
            }

            return this;
        }

        public TokenOptions NeverEndsWith(char symbol)
        {
            var set = _excludedAtEnd ??= new HashSet<char>();
            set.Add(symbol);
            return this;
        }

        public TokenOptions WithDistinctionRate(decimal rate)
        {
            _distinctionRate = rate;
            return this;
        }

        internal HashSet<char> ExcludedAtStart
        {
            get => _excludedAtStart;
        }

        internal HashSet<char> ExcludedAtEnd
        {
            get => _excludedAtEnd;
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace TokenGen.Generator
{
    public sealed class TokenOptions : IOptions<TokenOptions>
    {
        private int _length;
        private string _prefix;
        private string _postfix;
        private CharSet.Flags _sets;
        private int? _uniqueChars;
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

        internal CharSet.Flags SymbolFlags => _sets;

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
        /// Sets length of a random token to generate
        /// </summary>
        public TokenOptions WithLength(int length)
        {
            _length = length;
            return this;
        }

        public TokenOptions WithUniqueChars(int unique)
        {
            _uniqueChars = unique;
            return this;
        }

        /// <summary>
        /// Includes digits into alphabet of token symbols
        /// </summary>
        public TokenOptions WithDigits()
        {
            _sets |= CharSet.Flags.Digits;
            return this;
        }

        public TokenOptions WithLowerLetters()
        {
            _sets |= CharSet.Flags.LowerCaseLetters;
            return this;
        }

        public TokenOptions WithUpperLetters()
        {
            _sets |= CharSet.Flags.UpperCaseLetters;
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

        internal HashSet<char> ExcludedAtStart
        {
            get => _excludedAtStart;
        }

        internal HashSet<char> ExcludedAtEnd
        {
            get => _excludedAtEnd;
        }

        internal int? UniqueChars
        {
            get => _uniqueChars;
        }
    }
}
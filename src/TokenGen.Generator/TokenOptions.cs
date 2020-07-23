using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace TokenGen.Generator
{
    public sealed class TokenOptions : IOptions<TokenOptions>
    {
        private int _length;
        private string _prefix;
        private string _postfix;
        private CharSetOptions _charSets;
        private int _uniqueChars;
        private bool _allCharsUnique;
        private HashSet<char> _excludedAtStart;
        private HashSet<char> _excludedAtEnd;

        /// <summary>
        /// Sets desirable length of token
        /// </summary>
        public TokenOptions WithLength(int length)
        {
            _length = length;
            return this;
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
        /// Includes digits into alphabet of token symbols
        /// </summary>
        public TokenOptions WithDigits()
        {
            _charSets |= CharSetOptions.Digits;
            return this;
        }

        public TokenOptions WithLowerLetters()
        {
            _charSets |= CharSetOptions.LowerCaseLetters;
            return this;
        }

        public TokenOptions WithUpperLetters()
        {
            _charSets |= CharSetOptions.UpperCaseLetters;
            return this;
        }

        public TokenOptions WithUniqueChars(int count)
        {
            _uniqueChars = count;
            _allCharsUnique = false;
            return this;
        }

        public TokenOptions NeverStartsWith(char ch)
        {
            var set = _excludedAtStart ??= new HashSet<char>();
            set.Add(ch);
            return this;
        }

        public TokenOptions NeverStartsWith(IEnumerable<char> chars)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            var set = _excludedAtStart ??= new HashSet<char>();
            chars.ToList().ForEach(x => set.Add(x));

            return this;
        }

        public TokenOptions NeverEndsWith(char symbol)
        {
            var set = _excludedAtEnd ??= new HashSet<char>();
            set.Add(symbol);
            return this;
        }

        public TokenOptions NeverEndsWith(IEnumerable<char> chars)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            var set = _excludedAtEnd ??= new HashSet<char>();
            chars.ToList().ForEach(x => set.Add(x));
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

        internal int UniqueCharsRequested
        {
            get => _uniqueChars;
        }

        internal bool AllCharsUnique
        {
            get => _allCharsUnique;
        }

        internal string Prefix
        {
            get => _prefix;
        }

        internal string Postfix
        {
            get => _postfix;
        }

        /// <summary>
        /// Returns a user-specified length of token to generate
        /// </summary>
        internal int TokenLength
        {
            get => _length;
        }

        internal CharSetOptions CharSets
        {
            get => _charSets;
        }

        TokenOptions IOptions<TokenOptions>.Value
        {
            get
            {
                return this;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace TokenGen.Generator
{
    public sealed class TokenOptions : IOptions<TokenOptions>
    {
        private const string TokenPartSeparator = "-";

        private int _length;
        private string? _prefix;
        private string _postfix;
        private string _prefixSeparator = TokenPartSeparator;
        private string _postfixSeparator = TokenPartSeparator;
        private CharSetOptions _charSets;
        private readonly CountValue _distinctChars = new CountValue();
        private readonly HashSet<char> _excludedAtStart = new HashSet<char>();
        private readonly HashSet<char> _excludedAtEnd = new HashSet<char>();

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

        public TokenOptions WithPrefixSeparator(string separator)
        {
            _prefixSeparator = separator;
            return this;
        }

        public TokenOptions WithPostfixSeparator(string separator)
        {
            _postfixSeparator = separator;
            return this;
        }

        /// <summary>
        /// Includes digits as part of a token
        /// </summary>
        public TokenOptions WithDigits()
        {
            _charSets |= CharSetOptions.Digits;
            return this;
        }

        /// <summary>
        /// Includes lower-case English letters as part of a token
        /// </summary>
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

        public TokenOptions WithAllDistinctCharacters()
        {
            _distinctChars.All = true;
            return this;
        }

        public TokenOptions WithDistinctCharacters(int count, bool exact)
        {
            _distinctChars.Count = count;
            _distinctChars.Exact = exact;
            return this;
        }

        public TokenOptions WithDistinctCharacters(int count)
        {
            return WithDistinctCharacters(count, exact: false);
        }

        public TokenOptions NeverStartsWith(char ch)
        {
            _excludedAtStart.Add(ch);
            return this;
        }

        public TokenOptions NeverStartsWith(IEnumerable<char> chars)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            chars.ToList().ForEach(ch => _excludedAtStart.Add(ch));
            return this;
        }

        public TokenOptions NeverEndsWith(char ch)
        {
            _excludedAtEnd.Add(ch);
            return this;
        }

        public TokenOptions NeverEndsWith(IEnumerable<char> chars)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            chars.ToList().ForEach(ch => _excludedAtEnd.Add(ch));
            return this;
        }

        internal HashSet<char> CharsNeverAtStart
        {
            get => _excludedAtStart;
        }

        internal HashSet<char> CharsNeverAtEnd
        {
            get => _excludedAtEnd;
        }

        internal CountValue DistinctChars
        {
            get => _distinctChars;
        }

        internal string Prefix
        {
            get => _prefix;
        }

        internal string Postfix
        {
            get => _postfix;
        }

        internal string PrefixSeparator
        {
            get => _prefixSeparator;
        }

        internal string PostfixSeparator
        {
            get => _postfixSeparator;
        }

        /// <summary>
        /// Returns a user-specified length of token to generate
        /// </summary>
        internal int Length
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
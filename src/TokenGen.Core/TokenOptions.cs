using Microsoft.Extensions.Options;

namespace TokenGen.Core
{
    public sealed class TokenOptions : IOptions<TokenOptions>
    {
        private const decimal MaxUniquenessRate = 100.0M;

        private string _prefix;
        private string _postfix;
        private int _length;
        private decimal _uniquenessRate;
        private SymbolSet.Flags _sets;

        public TokenOptions()
        {
            _sets = SymbolSet.Flags.Digits;
            _length = -1;
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
        /// Sets desirable length of a random token to generate
        /// </summary>
        public TokenOptions WithLength(int length)
        {
            _length = length;
            return this;
        }

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

        public TokenOptions WithUniquenessRate(decimal uniqueness)
        {
            _uniquenessRate = uniqueness;
            return this;
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
        /// Gets length of a token to generate
        /// </summary>
        internal int Length
        {
            get => _length;
        }

        internal SymbolSet.Flags SymbolFlags
        {
            get => _sets;
        }

        internal decimal UniquenessRate
        {
            get => _uniquenessRate;
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

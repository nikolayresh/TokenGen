using System;
using System.Text;

namespace TokenGen.Generator
{
    internal sealed class GeneratedToken : IRandomToken
    {
        private readonly TokenOptions _options;
        private readonly string _token;

        public GeneratedToken(string token, TokenOptions options)
        {
            _token = token;
            _options = options;
        }

        public string Value
            => Construct(RandomTokenParts.Prefix | RandomTokenParts.Body | RandomTokenParts.Postfix);

        public string Prefix { get; }
        public string Postfix { get; }
        public string WithoutPrefix { get; }
        public string WithoutPostfix { get; }

        public bool HasDigits
        {
            get
            {
                return _options.SymbolFlags.HasFlag(SymbolSet.Flags.Digits)
                       && true;
            }
        }

        public void CopyTo(StringBuilder sb)
        {
            if (sb is null)
            {
                throw new ArgumentNullException();
            }
        }

        public void CopyTo(StringBuilder sb, RandomTokenParts parts)
        {
            if (sb is null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

        }

        public override string ToString()
        {
            return Value;
        }

        private string Construct(RandomTokenParts parts)
        {
            var result = new StringBuilder();

            if (parts.HasFlag(RandomTokenParts.Prefix) && _options.Prefix != null)
            {
                result.Append(_options.Prefix);
            }

            if (parts.HasFlag(RandomTokenParts.Body))
            {
                result.Append(_token);
            }

            if (parts.HasFlag(RandomTokenParts.Postfix) && _options.Postfix != null)
            {
                result.Append(_options.Postfix);
            }

            return result.ToString();
        }
    }
}
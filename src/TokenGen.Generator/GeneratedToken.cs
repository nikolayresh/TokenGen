using System;
using System.Text;

namespace TokenGen.Generator
{
    internal sealed class GeneratedToken : IToken
    {
        private readonly TokenOptions _options;
        private readonly string _token;

        public GeneratedToken(string token, TokenOptions options)
        {
            _token = token;
            _options = options;
        }

        public string Value
            => Construct(TokenParts.Prefix | TokenParts.Body | TokenParts.Postfix);

        public string Prefix { get; }
        public string Postfix { get; }
        public string WithoutPrefix { get; }
        public string WithoutPostfix { get; }

        public void CopyTo(StringBuilder sb)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(StringBuilder sb, TokenParts parts)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Value;
        }

        private string Construct(TokenParts parts)
        {
            var result = new StringBuilder();

            if (parts.HasFlag(TokenParts.Prefix) && _options.Prefix != null) result.Append(_options.Prefix);

            if (parts.HasFlag(TokenParts.Body)) result.Append(_token);

            return result.ToString();
        }
    }
}
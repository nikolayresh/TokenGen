using System.Text;

namespace TokenGen.Core
{
    internal sealed class GeneratedToken : IToken
    {
        private readonly string _token;
        private readonly TokenOptions _options;

        public GeneratedToken(string token, TokenOptions options)
        {
            _token = token;
            _options = options;
        }

        public string Value
        {
            get => Construct(TokenParts.Prefix | TokenParts.Body | TokenParts.Postfix);
        }
        public string Prefix { get; }
        public string Postfix { get; }
        public string WithoutPrefix { get; }
        public string WithoutPostfix { get; }
        public void CopyTo(StringBuilder sb)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(StringBuilder sb, TokenParts parts)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return Value;
        }

        private string Construct(TokenParts parts)
        {
            var result = new StringBuilder();

            if (parts.HasFlag(TokenParts.Prefix) && _options.Prefix != null)
            {
                result.Append(_options.Prefix);
            }

            if (parts.HasFlag(TokenParts.Body))
            {
                result.Append(_token);
            }

            return result.ToString();
        }
    }
}
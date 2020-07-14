using System;
using System.Text;

namespace TokenGen.Generator
{
    internal sealed class RandomToken : IRandomToken
    {
        private readonly TokenOptions _options;
        private readonly string _token;

        public RandomToken(string token, TokenOptions options)
        {
            _token = token;
            _options = options;
        }

        public string Value
        {
            get
            {
                return Construct(RandomTokenParts.Prefix | RandomTokenParts.Payload | RandomTokenParts.Postfix);
            }
        }

        public string Prefix
        {
            get
            {
                return Construct(RandomTokenParts.Prefix);
            }
        }

        public string Postfix
        {
            get
            {
                return Construct(RandomTokenParts.Postfix);
            }
        }

        public string WithoutPrefix
        {
            get
            {
                return Construct(RandomTokenParts.Payload | RandomTokenParts.Postfix);
            }
        }

        public string WithoutPostfix
        {
            get
            {
                return Construct(RandomTokenParts.Prefix | RandomTokenParts.Payload);
            }
        }

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
            CopyTo(sb, RandomTokenParts.Prefix | RandomTokenParts.Payload | RandomTokenParts.Postfix);
        }

        public void CopyTo(StringBuilder sb, RandomTokenParts parts)
        {
            if (sb is null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            Construct(parts, sb);
        }

        public override string ToString()
        {
            return Value;
        }

        private string Construct(RandomTokenParts parts, StringBuilder sb = null)
        {
            sb ??= new StringBuilder();

            if (parts.HasFlag(RandomTokenParts.Prefix) && _options.Prefix != null)
            {
                sb.Append(_options.Prefix);
            }

            if (parts.HasFlag(RandomTokenParts.Payload))
            {
                sb.Append(_token);
            }

            if (parts.HasFlag(RandomTokenParts.Postfix) && _options.Postfix != null)
            {
                sb.Append(_options.Postfix);
            }

            return sb.ToString();
        }
    }
}
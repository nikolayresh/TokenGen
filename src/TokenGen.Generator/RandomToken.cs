using System;
using System.Text;

namespace TokenGen.Generator
{
    internal sealed class RandomToken : IRandomToken
    {
        private readonly string _payload;
        private readonly TokenOptions _options;
        
        internal RandomToken(string payload, TokenOptions options)
        {
            _payload = payload;
            _options = options;
        }

        public string Value
        {
            get
            {
                return Construct(RandomTokenParts.Prefix | RandomTokenParts.Payload | RandomTokenParts.Postfix);
            }
        }

        public string Payload
        {
            get
            {
                return Construct(RandomTokenParts.Payload);
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
                return CharSetManager.ContainsAnyDigit(Value);
            }
        }

        public bool HasLowerCaseLetters
        {
            get
            {
                return CharSetManager.ContainsAnyLowerLetter(Value);
            }
        }

        public bool HasUpperCaseLetters
        {
            get
            {
                return CharSetManager.ContainsAnyUpperLetter(Value);
            }
        }

        public bool PayloadHasDigits
        {
            get
            {
                return CharSetManager.ContainsAnyDigit(_payload);
            }
        }

        public bool PayloadHasLowerCaseLetters
        {
            get
            {
                return CharSetManager.ContainsAnyLowerLetter(_payload);
            }
        }

        public bool PayloadHasUpperCaseLetters
        {
            get
            {
                return CharSetManager.ContainsAnyUpperLetter(_payload);
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

            if ((parts & RandomTokenParts.Prefix) != 0 && _options.Prefix != null)
            {
                sb.Append(_options.Prefix);

                if (_options.PrefixSeparator != null)
                {
                    sb.Append(_options.PrefixSeparator);
                }
            }

            if ((parts & RandomTokenParts.Payload) != 0)
            {
                sb.Append(_payload);
            }

            if ((parts & RandomTokenParts.Postfix) != 0 && _options.Postfix != null)
            {
                if (_options.PostfixSeparator != null)
                {
                    sb.Append(_options.PostfixSeparator);
                }

                sb.Append(_options.Postfix);
            }

            return (sb.Length > 0) ? sb.ToString() : null;
        }
    }
}
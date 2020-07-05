using System.Text;

namespace TokenGen.Core
{
    /// <summary>
    /// Interface of a randomly generated token
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// Gets full value of a generated token
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets prefix part of a generated token
        /// </summary>
        string Prefix { get; }

        /// <summary>
        /// Gets postfix part of a generated token
        /// </summary>
        string Postfix { get; }

        /// <summary>
        /// Gets value of a generated token without a prefix part
        /// </summary>
        string WithoutPrefix { get; }

        /// <summary>
        /// Gets value of a generated token without postfix part
        /// </summary>
        string WithoutPostfix { get; }

        void CopyTo(StringBuilder sb);

        void CopyTo(StringBuilder sb, TokenParts parts);
    }
}
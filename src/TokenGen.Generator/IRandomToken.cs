using System.Text;

namespace TokenGen.Generator
{
    /// <summary>
    /// Interface of a randomly generated alphanumeric token
    /// </summary>
    public interface IRandomToken
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
        ///     Gets postfix part of a generated token
        /// </summary>
        string Postfix { get; }

        /// <summary>
        ///     Gets value of a generated token without prefix part
        /// </summary>
        string WithoutPrefix { get; }

        /// <summary>
        /// Gets value of a generated token without postfix part
        /// </summary>
        string WithoutPostfix { get; }

        /// <summary>
        /// Returns a boolean value whether token contains any digit symbol
        /// </summary>
        bool HasDigits { get; }

        void CopyTo(StringBuilder sb);

        void CopyTo(StringBuilder sb, RandomTokenParts parts);
    }
}
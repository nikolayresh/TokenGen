using System.Text;

namespace TokenGen.Generator
{
    /// <summary>
    /// Interface of a randomly generated alphanumeric token
    /// </summary>
    public interface IRandomToken
    {
        /// <summary>
        /// Returns full/complete value of a generated token
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Returns payload part of a generated token
        /// </summary>
        string Payload { get; }

        /// <summary>
        /// Returns prefix part of a generated token
        /// </summary>
        string Prefix { get; }

        /// <summary>
        /// Returns postfix part of a generated token
        /// </summary>
        string Postfix { get; }

        /// <summary>
        /// Returns value of a generated token without prefix part
        /// </summary>
        string WithoutPrefix { get; }

        /// <summary>
        /// Returns value of a generated token without postfix part
        /// </summary>
        string WithoutPostfix { get; }

        /// <summary>
        /// Returns a boolean value whether token contains at least a single digit
        /// </summary>
        bool HasDigits { get; }

        /// <summary>
        /// Returns a boolean value whether a generated token contains any lower-case letter
        /// </summary>
        bool HasLowerCaseLetters { get; }

        /// <summary>
        /// Returns a boolean value whether a generated token contains any upper-case letter
        /// </summary>
        bool HasUpperCaseLetters { get; }

        /// <summary>
        /// Appends full/complete content of generated token to a specified string builder 
        /// </summary>
        void CopyTo(StringBuilder sb);

        void CopyTo(StringBuilder sb, RandomTokenParts parts);
    }
}
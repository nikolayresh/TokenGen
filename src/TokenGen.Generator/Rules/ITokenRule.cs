namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Interface of a rule that newly generated tokens should stick to
    /// </summary>
    internal interface ITokenRule
    {
        /// <summary>
        /// Returns a boolean value whether this rule was successfully applied on a specified token
        /// </summary>
        bool TryApply(string token);

        /// <summary>
        /// Returns a boolean value whether this rule can accept
        /// a failed token if to shuffle its content.
        /// In this case a new token will not be created by generator
        /// </summary>
        bool CanReApplyOnShuffledToken { get; }
    }
}
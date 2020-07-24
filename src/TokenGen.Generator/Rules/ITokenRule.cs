namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Interface of a rule that newly generated tokens should stick to
    /// </summary>
    internal interface ITokenRule
    {
        /// <summary>
        /// Returns a boolean value whether this rule accepted a generated token
        /// </summary>
        bool TryPass(string token);

        /// <summary>
        /// Returns a boolean value whether this rule can accept
        /// a failed token if to shuffle its content.
        /// In this case a new token will not be generated
        /// </summary>
        bool ShuffleTokenOnFail { get; }
    }
}
namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Interface of a rule that newly generated tokens should stick to
    /// </summary>
    internal interface ITokenRule
    {
        /// <summary>
        /// Returns a boolean value whether rule was passed
        /// </summary>
        /// <param name="token">A generated token</param>
        bool TryPass(string token);
    }
}
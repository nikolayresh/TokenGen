namespace TokenGen.Core.Rules
{
    /// <summary>
    /// Interface of a rule to check for token validity
    /// </summary>
    internal interface IGenerateRule
    {
        bool TryPass(string token);
    }
}
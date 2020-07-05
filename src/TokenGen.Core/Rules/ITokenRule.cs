namespace TokenGen.Core.Rules
{
    /// <summary>
    /// Interface of a rule to check for token validity
    /// </summary>
    internal interface ITokenRule
    {
        bool TryPass(string token);
    }
}
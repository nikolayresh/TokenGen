namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Marker interface for token rules that
    /// can be fixed without re-generating a new token
    /// by means of randomized character shuffling
    /// </summary>
    internal interface IShuffleOnFail
    {
    }
}
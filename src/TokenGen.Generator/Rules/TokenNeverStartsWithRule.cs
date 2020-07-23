namespace TokenGen.Generator.Rules
{
    internal class TokenNeverStartsWithRule : BaseTokenRule, IShuffleOnFailRule
    {
        public TokenNeverStartsWithRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var firstChar = token[0];

            return !Options.ExcludedAtStart.Contains(firstChar);
        }
    }
}

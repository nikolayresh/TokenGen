namespace TokenGen.Generator.Rules
{
    internal class TokenNeverStartsWithRule : BaseTokenRule
    {
        public TokenNeverStartsWithRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var firstSymbol = token[0];

            return !Options.ExcludedAtStart.Contains(firstSymbol);
        }
    }
}

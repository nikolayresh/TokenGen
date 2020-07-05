namespace TokenGen.Generator.Rules
{
    internal class TokenNeverEndsWithRule : BaseTokenRule
    {
        public TokenNeverEndsWithRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var lastSymbol = token[^1];

            return !Options.ExcludedAtEnd.Contains(lastSymbol);
        }
    }
}

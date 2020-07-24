namespace TokenGen.Generator.Rules
{
    internal class TokenNeverEndsWithRule : BaseTokenRule
    {
        public TokenNeverEndsWithRule(TokenOptions options) : base(options)
        {
        }

        public override bool ShuffleTokenOnFail
        {
            get => true;
        }

        public override bool TryPass(string token)
        {
            var lastChar = token[^1];

            return !Options.CharsNeverAtEnd.Contains(lastChar);
        }
    }
}

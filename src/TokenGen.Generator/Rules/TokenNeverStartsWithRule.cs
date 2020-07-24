namespace TokenGen.Generator.Rules
{
    internal class TokenNeverStartsWithRule : BaseTokenRule
    {
        public TokenNeverStartsWithRule(TokenOptions options) : base(options)
        {
        }

        public override bool ShuffleTokenOnFail
        {
            get => true;
        }

        public override bool TryPass(string token)
        {
            var firstChar = token[0];

            return !Options.CharsNeverAtStart.Contains(firstChar);
        }
    }
}

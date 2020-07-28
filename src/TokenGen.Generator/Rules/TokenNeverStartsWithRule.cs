namespace TokenGen.Generator.Rules
{
    internal class TokenNeverStartsWithRule : BaseTokenRule
    {
        public TokenNeverStartsWithRule(TokenOptions options) : base(options)
        {
        }

        public override bool CanApplyOnShuffledToken
        {
            get => true;
        }

        public override bool TryApply(string token)
        {
            var firstChar = token[0];

            return !Options.CharsNeverAtStart.Contains(firstChar);
        }
    }
}

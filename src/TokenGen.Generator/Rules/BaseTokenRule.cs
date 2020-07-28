namespace TokenGen.Generator.Rules
{
    internal abstract class BaseTokenRule : ITokenRule
    {
        protected BaseTokenRule(TokenOptions options)
        {
            Options = options;
        }

        protected TokenOptions Options
        {
            get;
        }

        public abstract bool TryApply(string token);

        public virtual bool CanReApplyOnShuffledToken
        {
            get => false;
        }
    }
}
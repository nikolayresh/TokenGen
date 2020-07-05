namespace TokenGen.Generator.Rules
{
    internal abstract class BaseTokenRule : ITokenRule
    {
        protected BaseTokenRule(TokenOptions options)
        {
            Options = options;
        }

        protected internal TokenOptions Options
        {
            get;
        }

        public abstract bool TryPass(string token);
    }
}
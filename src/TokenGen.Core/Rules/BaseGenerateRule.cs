namespace TokenGen.Core.Rules
{
    internal abstract class BaseGenerateRule : IGenerateRule
    {
        protected BaseGenerateRule(TokenOptions options)
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

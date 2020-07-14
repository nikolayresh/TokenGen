using System.Collections.Generic;
using System.Linq;

namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Rule that checks for uniqueness of token symbols 
    /// </summary>
    internal class TokenUniquenessRule : BaseTokenRule
    {
        private readonly Dictionary<char, int> _frequencies;

        internal TokenUniquenessRule(TokenOptions options) : base(options)
        {
            _frequencies = new Dictionary<char, int>();
        }

        public override bool TryPass(string token)
        {
            _frequencies.Clear();

            // initial rate of uniqueness (100%)
            var uniqueness = 100.0M;

            for (var i = 0; i < Options.Length; i++)
            {
                var current = token[i];

                if (!_frequencies.ContainsKey(current))
                {
                    _frequencies[current] = 0;
                }

                _frequencies[current]++;
            }

            _frequencies.Where(x => x.Value > 1).Select(x => x.Value)
                .ToList().ForEach(frequency =>
                {
                    uniqueness -= 100 * ((decimal) frequency / Options.Length);
                });

            return uniqueness >= Options.UniquenessRate;
        }
    }
}
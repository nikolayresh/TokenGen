using System.Collections.Generic;
using System.Linq;

namespace TokenGen.Generator.Rules
{
    internal class RequiredUniquenessRule : BaseTokenRule
    {
        private readonly Dictionary<char, StructRef<int>> _repeatsMap;

        internal RequiredUniquenessRule(TokenOptions options) : base(options)
        {
            _repeatsMap = new Dictionary<char, StructRef<int>>();
        }

        public override bool TryPass(string token)
        {
            _repeatsMap.Clear();

            for (var i = 0; i < token.Length; i++)
            {
                var ch = token[i];

                if (!_repeatsMap.TryGetValue(ch, out var repeats))
                {
                    repeats = new StructRef<int>();
                    _repeatsMap[ch] = repeats;
                }

                repeats.Value++;
            }

            var uniquenessRate = 100 * ((decimal) _repeatsMap.Keys.Count / _repeatsMap.Values.Sum(x => x.Value));

            return uniquenessRate >= Options.UniquenessRate;
        }
    }
}
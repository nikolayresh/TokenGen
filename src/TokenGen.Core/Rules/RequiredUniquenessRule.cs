using System.Collections.Generic;
using System.Linq;

namespace TokenGen.Core.Rules
{
    internal class RequiredUniquenessRule : BaseGenerateRule
    {
        private readonly Dictionary<char, StructRef<int>> _repeatsMap;

        public RequiredUniquenessRule(TokenOptions options) : base(options)
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

           var uniqueness = (int)(100 * ((decimal) _repeatsMap.Keys.Count / _repeatsMap.Values.Sum(x => x.Value)));

           return uniqueness >= Options.Uniqueness;
        }
    }
}

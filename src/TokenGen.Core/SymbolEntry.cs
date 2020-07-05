using System.Collections.Generic;
using System.Diagnostics;

namespace TokenGen.Core
{
    internal sealed class SymbolEntry
    {
        /// <summary>
        /// Gets or sets maximal count of symbol repeats within token
        /// </summary>
        internal int? MaxRepeats
        {
            get;
            set;
        }
    }
}
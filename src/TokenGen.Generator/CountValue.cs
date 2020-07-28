namespace TokenGen.Generator
{
    internal sealed class CountValue
    {
        private bool _all;
        private int? _count;
        private bool _exact;

        internal bool All
        {
            get => _all;
            set
            {
                _all = value;

                if (_all)
                {
                    _count = null;
                    _exact = false;
                }
            }
        }

        internal int? Count
        {
            get => _count;
            set
            {
                if (value != null)
                {
                    _count = value;
                    _all = false;
                }
            }
        }

        internal bool Exact
        {
            get => _exact;
            set => _exact = value;
        }
    }
}

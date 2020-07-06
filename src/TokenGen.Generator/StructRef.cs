namespace TokenGen.Generator
{
    /// <summary>
    /// Class wrapper around structure
    /// </summary>
    internal sealed class StructRef<TStruct> where TStruct : struct
    {
        private TStruct _value;

        internal StructRef() : this(default)
        {
        }

        internal StructRef(TStruct valueOnInit)
        {
            _value = valueOnInit;
        }

        public TStruct Value
        {
            get => _value;
            set => _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
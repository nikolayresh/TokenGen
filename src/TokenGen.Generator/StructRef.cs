namespace TokenGen.Generator
{
    /// <summary>
    /// Class wrapper around structure
    /// </summary>
    internal sealed class StructRef<T> where T : struct
    {
        private T _value;

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
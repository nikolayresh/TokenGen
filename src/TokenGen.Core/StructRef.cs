namespace TokenGen.Core
{
    internal sealed class StructRef<T> where T : struct
    {
        private T _value;

        public T Value
        {
            get => _value;
            set => _value = value;
        }
    }
}
using System;

namespace fourth
{
    public class LeafNode<T, V> : Node<V>
    {
        public T Value { get; set; }
        public Func<T, V> Converter { get; set; }

        public LeafNode(T value, Func<T, V> converter)
        {
            Value = value;
            Converter = converter;
        }

        public override V Calculate()
        {
            return Converter(Value);
        }
    }
}
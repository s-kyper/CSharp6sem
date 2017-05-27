using System;

namespace fourth
{
    public class UnaryNode<L, V> : Node<V>
    {
        public Node<L> Left { get; set;}
        public Func<L, V> Operation { get; set; }
        
        public UnaryNode(Node<L> left, Func<L, V> operation)
        {
            Left = left;
            Operation = operation;
        }

        public override V Calculate()
        {
            return Operation(Left.Calculate());
        }
    }
}
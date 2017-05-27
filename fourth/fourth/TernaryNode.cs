using System;

namespace fourth
{
    public class TernaryNode<L, C, R, V> : Node<V>
    {
        public Node<L> Left { get; set;}
        public Node<C> Center { get; set; }
        public Node<R> Right { get; set; }
        public Func<L, C, R, V> Operation { get; set; }
        
        public TernaryNode(Node<L> left, Node<C> center, Node<R> right, Func<L, C, R, V> operation)
        {
            Left = left;
            Center = center;
            Right = right;
            Operation = operation;
        }

        public override V Calculate()
        {
            return Operation(Left.Calculate(), Center.Calculate(), Right.Calculate());
        }
    }
}
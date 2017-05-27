using System;

namespace fourth
{
    public class TreeNode<L,R,V> : Node<V>
    {
        public Node<L> Left { get; set;}
        public Node<R> Right { get; set; }
        public Func<L, R, V> Operation { get; set; }
        
        public TreeNode(Node<L> left, Node<R> right, Func<L, R, V> operation)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }

        public override V Calculate()
        {
            return Operation(Left.Calculate(), Right.Calculate());
        }
    }
}
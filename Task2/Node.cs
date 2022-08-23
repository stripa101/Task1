using System;
namespace Task2
{
    internal class Node: INode
    {
        public Int32 Value { get; set; } = 0;
        public INode Left { get; set; }
        public INode Right { get; set; }
        public Node(Int32 value) => Value = value;

    }
}

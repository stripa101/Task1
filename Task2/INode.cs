using System;
namespace Task2
{
    public interface INode
    {
        Int32 Value { get; set; }
        INode Left { get; set; }
        INode Right { get; set; }
    }
}

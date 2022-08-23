using System;
using System.Collections.Generic;
namespace Task2
{
    internal class Tree
    {
        private INode _root;
        public Tree(INode root) => this._root = root;
        public void AddNewNode(Int32 value) => AddNewNode(_root, value);
        private void AddNewNode(INode root, Int32 value)
        {
            if (root.Value > value)
            {
                if (root.Left == null)
                {
                    root.Left = new Node(value);
                    return;
                }
                AddNewNode(root.Left, value);
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = new Node(value);
                    return;
                }
                AddNewNode(root.Right, value);
            }
        }
        /// <summary>
        /// Поиск в ширину
        /// </summary>
        /// <param name="value">Значение которое мы ищим</param>
        /// <returns>Найденный NODE или NULL</returns>
        public INode BFS(Int32 value)
        {
            Queue<INode> nodes = new Queue<INode>();
            nodes.Enqueue(_root);
            while (nodes.Count > 0)
            {
                INode node = nodes.Dequeue();
                if (node.Value == value)
                {
                    return node;
                }
                else
                {
                    if (node.Left != null)
                    {
                        nodes.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        nodes.Enqueue(node.Right);
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Поиск в глубину
        /// </summary>
        /// <param name="value">Значение которое мы ищим</param>
        /// <returns>Найденный NODE или NULL</returns>
        public INode DFS(Int32 value) => DFS(_root, value);
        private INode DFS(INode node, Int32 value)
        {
            if (node?.Value == value)
            {
                return node;
            }
            if (node?.Value < value)
            {
                return DFS(node.Right, value);
            }
            if (node?.Value > value)
            {
                return DFS(node.Left, value);
            }
            return null;
        }
    }
}

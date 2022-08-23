using System;
namespace Task2
{
    internal class Program
    {  
        //1.	Написать процедуры обхода бинарного дерева поиска в
        //глубину (preorder) и в ширину.
        //2.	Организовать функцию вставки значения в бинарное дерево

        static void Main(string[] args)
        {
            var root = new Node(25);
            Tree tree = new Tree(root);
            tree.AddNewNode(30);
            tree.AddNewNode(31);
            tree.AddNewNode(27);
            tree.AddNewNode(26);
            tree.AddNewNode(23);
            tree.AddNewNode(24);
            tree.AddNewNode(41);

            INode node = tree.DFS(25);
            Console.WriteLine(node.Value);

            INode node2 = tree.BFS(24);
            Console.WriteLine(node2.Value);
            Console.ReadLine();
        }
    }
}

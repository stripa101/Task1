using System;
namespace Task3
{
    internal class Program
    {
        //Написать две функции:
        //1) замены элемента в списке СhangeValue(T,int);
        //2) объединения двух списков Plus(CollectionGeneric<T>);
        //Задача с ошибкой в классах методы, а не функции

        static void Main(string[] args)
        {
            var collectionGeneric = new CollectionGeneric<Int32>();
            collectionGeneric.AddNewNodeEnd(55);
            collectionGeneric.AddNewNodeEnd(5);
            collectionGeneric.AddNewNodeEnd(3);
            Console.WriteLine("\n====List 1====\n");
            collectionGeneric.Show();

            Console.WriteLine("\n====List 1 Сhange====\n");
            collectionGeneric.СhangeValue(666, 1);
            collectionGeneric.Show();

            var collectionGeneric2 = new CollectionGeneric<Int32>();
            collectionGeneric2.AddNewNodeEnd(33);
            collectionGeneric2.AddNewNodeEnd(13);
            Console.WriteLine("\n====List 2====\n");
            collectionGeneric2.Show();

            Console.WriteLine("\n====List 1 + List 2====\n");
            collectionGeneric.Plus(collectionGeneric2);
            collectionGeneric.Show();
            Console.ReadLine();
        }
    }
}

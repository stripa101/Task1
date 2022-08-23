using System;
using System.Collections.Generic;
using System.Reflection;
namespace Task3
{
    internal class CollectionGeneric<T>
    {
        private Object _head;
        /// <summary>
        /// Добавление нового узла
        /// </summary>
        /// <param name="value">Значение узла</param>
        public void AddNewNodeEnd(T value)
        {
            var assembly = Assembly.Load("Task3");
            var assemblyType = assembly.GetType("Task3.ListNode`1");
            var listInt = assemblyType.MakeGenericType(value.GetType());
            var ctr = listInt.GetTypeInfo().GetConstructors()[0];
            var node = ctr.Invoke(null);
            var fieldValue = node.GetType().GetTypeInfo().GetDeclaredField("Value");
            var fieldNext = node.GetType().GetTypeInfo().GetDeclaredField("Next");
            fieldNext.SetValue(node, null);
            fieldValue.SetValue(node, value);
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                Object step = _head;
                while (step != null)
                {
                    var next = step.GetType().GetTypeInfo().GetDeclaredField("Next");
                    var nextNode = next.GetValue(step);
                    if (nextNode == null)
                    {
                        next.SetValue(step, node);
                        break;
                    }
                    step = nextNode;
                }
            }
        }
        /// <summary>
        /// Вывод листа
        /// </summary>
        public void Show()
        {
            dynamic step = _head;
            while (step != null)
            {
                T nodeValue = step.Value;
                Console.WriteLine(nodeValue);
                dynamic nodeNext = step.Next;
                step = nodeNext;
            }
        }
        /// <summary>
        /// Замены элемента в списке
        /// </summary>
        /// <param name="value">Новое значение</param>
        /// <param name="index">Index заменяемного узла</param>
        public void СhangeValue(T value, Int32 index)
        {
            Object step = _head;
            Int32 i = 0;
            while (step != null && i <= index)
            {
                if (i == index)
                {
                    var fieldValue = step.GetType().GetTypeInfo().GetDeclaredField("Value");
                    fieldValue.SetValue(step, value);
                    break;
                }
                var next = step.GetType().GetTypeInfo().GetDeclaredField("Next");
                var nextNode = next.GetValue(step);
                step = nextNode;
                i++;
            }
        }
        /// <summary>
        /// Объединения двух списков
        /// </summary>
        /// <param name="two">Список для объединения</param>
        public void Plus(CollectionGeneric<T> list)
        {
            Object step = _head;
            while (true)
            {
                var next = step.GetType().GetTypeInfo().GetDeclaredField("Next");
                var nextNode = next.GetValue(step);
                if (nextNode == null)
                {
                    next.SetValue(step, list._head);
                    break;
                }
                step = nextNode;
            }
        }
    }
}

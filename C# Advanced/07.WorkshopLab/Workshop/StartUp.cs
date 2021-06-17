using System;

namespace Workshop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.AddFirst("one");
            doublyLinkedList.AddFirst("two");
            doublyLinkedList.AddFirst("three");
            doublyLinkedList.AddLast("four");
            doublyLinkedList.AddLast("five");
            doublyLinkedList.AddLast("six");

            doublyLinkedList.RemoveFirst();
            doublyLinkedList.RemoveLast();

            doublyLinkedList.ForEach(Console.WriteLine);
        }
    }
}

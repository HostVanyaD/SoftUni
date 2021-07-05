using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myFunnyStack = new StackOfStrings();

            Console.WriteLine(myFunnyStack.IsEmpty());

            string[] newItems = new string[] { "smile", "laugh", "play" };
           
            myFunnyStack.AddRange(newItems);

            foreach (var word in myFunnyStack)
            {
                Console.WriteLine(word);
            }
        }
    }
}

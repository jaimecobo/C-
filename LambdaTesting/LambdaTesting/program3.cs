using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTesting
{
    internal class program3
    {
        static void Main()
        {
            
          

            test one = new test() { s = "Brian", age = 15, state1 = 'F', state2 = 'L' };
            test two = new test() { s = "Carol", age = 12, state1 = 'I', state2 = 'L' };
            test three = new test() { s = "August", age = 4, state1 = 'G', state2 = 'A' };
           
            List<test> listt = new List<test>() { one, two, three };
            List<string> lists = new List<string>() { "zero", "one", "two", "three", "four", "five" };

            var a = listt.ToDictionary(t => t.state2);
           foreach(var x in a)
            {
                Console.WriteLine(x);
            }
        }
    }
}

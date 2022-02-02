using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//   variable => expression involving the variable

//    x =>  x> 10                              => is pronounced   'such that'
//    x =>  x%2 == 0                           x is even
//    x =>  (x+10)/3.0

//   (variable1,variable2) => expression involving the two variables

// (x,y) => x>y*2
// (x,y) => y<x.Length


namespace LambdaTesting
{
    class test
    {
        public string s { get; set; }
        public int age { get; set; }
        public char state1 { get; set; }
        public char state2 { get; set; }

        public override string ToString()
        {
            return $"s={s} age={age} state={state1}{state2}";
        }
    }
    internal class Program2
    {
        static void Mainold()
        {
            test one = new test() { s = "Brian", age = 15, state1 = 'F', state2 = 'L' };
            test two = new test() { s = "Carol", age = 12, state1 = 'I', state2 = 'L' };
            test three = new test() { s = "August", age = 4, state1 = 'G', state2 = 'A' };
            ////Predicate<test> question = startswithb;
            //Check(one, t => t.s.Length==3);
            List<test> all = new List<test>() { one, two, three };
            
            List<test> answer = select(all, t => t.age > 8);
            
            foreach (test t in answer )
            {
                Console.WriteLine(t);
            }
        }

        static void Check(test t, Predicate<test> p)
        {
            if (p == null) return;
            Console.WriteLine($"Testing the object '{t}' to see if it meets the predicate");
            bool answer = p(t);
            Console.WriteLine(answer);
        }


        static List<test> select(List<test> input, Predicate<test> p)
        {
            List<test> answer = new List<test>();
            foreach(test t in input)
            {
                if (p(t))
                {
                    answer.Add(t);
                }
            }
            return answer;
        }

        //static bool startswithb(test t)
        //{
        //    return t.s.StartsWith("B");
        //}
        //static bool startswithx(test t)
        //{
        //    return t.s.StartsWith("x");
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTesting
{
   
    internal class Class1
    {
        public static void Main()
        {
            Class1 c = new Class1();
            c.property = 1100;

        }
    

        int field;
        int method() 
        { 
            return 0; 
        }
        int property 
        { 
            get 
            { 
                return field; 
            }  
            set 
            { 
                if ((value <0)||(value>255))
                {
                    throw new Exception("");
                }
                    

                
                field = value; 
            } 
        }

        

    }
}

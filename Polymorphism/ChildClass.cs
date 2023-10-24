using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class ChildClass:BaseClass
    {
       
       public void printChild() {
            Console.WriteLine("printing from child");
        }
       
    }
}

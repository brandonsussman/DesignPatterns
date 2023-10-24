using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
   public  class BaseClass 
    {
      public   BaseClass() { }
        public virtual void print()
        {

            Console.WriteLine("Printing from base class method");
        }
    }
}

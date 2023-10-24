using System.Runtime.ConstrainedExecution;

namespace TemplateMethodPattern {
    internal class Program
    {
        private static void Main(string[] args)
        {
            AbstractTemplate directions= new Directions();
            directions.templateMethod();
        }


    }

    public abstract class AbstractTemplate{
   public  void templateMethod()
        {
            step1();
            step2();
            step3();
        }
        public abstract void step1();
        public abstract void step2();
        public abstract void step3();


    } 
    public class Directions : AbstractTemplate
    {
        public Directions() { }
      
        public override void step1()
        {
            Console.WriteLine("directions turn left");
        }

       

        public override void step2()
        {
            Console.WriteLine("directions turn left");
        }

       

        public override void step3()
        {
            Console.WriteLine("directions turn left");
        }
    }


}
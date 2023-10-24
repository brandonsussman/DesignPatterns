

using Polymorphism;

internal class Program
{
    private static void Main(string[] args)
    {
        ChildClass childClass = new ChildClass();
        baseParm(childClass);
        void baseParm(BaseClass baseClass) {
            baseClass.print();
        
        }
        childClass.printChild();
    }
}
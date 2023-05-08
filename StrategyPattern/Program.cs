using System.Dynamic;
using System.Net.Security;

public class Program
{

    public interface IOperation
    {


        public int Calculation(int num1, int num2);

    }
    public class AddOperation : IOperation {
        public int Calculation(int num1, int num2) { return num1 + num2; }
    }
    public class SubtractOperation : IOperation
    {
        public int Calculation(int num1, int num2) { return num1 - num2; }
    }
    public class OperationContext{
        IOperation _operation;
       
        public IOperation Operation { set => _operation = value; }
        public int ExcuteCalculation(int num1,int num2) { return  _operation.Calculation(num1, num2); }
    }
    private static void Main(string[] args)
    {
        OperationContext add = new OperationContext();
        add.Operation = new AddOperation();
    
        int res = add.ExcuteCalculation(1, 2);
        
       
     Console.WriteLine(res);

    }
}
public class Pizza
{
    private double cost;
    public double calculateCost(){ return 100; }

    public void display() { Console.WriteLine("Plain Pizza"); }

}

public abstract class Topping : Pizza 
{
    private Pizza _pizza;
    public Topping(Pizza pizza)
    {
        _pizza= pizza;
    }
}
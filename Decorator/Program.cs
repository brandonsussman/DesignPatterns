
Pizza pizza = new Pizza();
pizza = new Tomato(pizza);
pizza = new Cheese(pizza);
pizza = new Cheese(pizza);
pizza.display();
Console.WriteLine(pizza.calculateCost()) ;
public class Pizza
{
    private double cost;

    public Pizza()
    {
        cost = 100;
    }
    public virtual double calculateCost(){ return cost; }

    public virtual void display() { Console.WriteLine($"Plain Pizza {cost}"); }

}

public abstract class Topping : Pizza 
{
    private Pizza _pizza;
  
    public Topping(Pizza pizza)
    {
        _pizza= pizza;
    }

    public override double calculateCost() { return _pizza.calculateCost(); }

    public override void display() { _pizza.display(); }

    
}


public class Cheese : Topping
{
    private double cost;
    public Cheese(Pizza pizza) : base(pizza)
    {
        cost = 20;
    }

    public override double calculateCost() { return base.calculateCost() +cost; }

    public override void display() 
    { base.display(); 
        Console.WriteLine($"Cheese {cost}"); }

}

public class Tomato : Topping
{
    private double cost;

    public Tomato(Pizza pizza) : base(pizza)
    {
        cost = 20;
    }

    public override double calculateCost() { return base.calculateCost() + 20; }

    public override void display() {
        base.display();
        Console.WriteLine($"Tomato {cost}"); }

}
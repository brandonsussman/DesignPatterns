


Factory factoryA = new FactoryA();
Product productA = factoryA.CreateProduct();
Console.WriteLine(productA.display());


Factory factoryB= new FactoryB();
Product productB = factoryB.CreateProduct();
Console.WriteLine(productB.display());

abstract class Product
{

    public abstract string display();
}

class ConcreteProductA :Product
{
    public override string display()
    {
        return "This is product A";
    }
}

class ConcreteProductB : Product
{
    public override string display()
    {
        return "This is product B";
    }
}


abstract class Factory 
{
    public abstract Product CreateProduct();    
}


class FactoryA : Factory {
    public override Product CreateProduct() { return new ConcreteProductA(); }
}


class FactoryB : Factory
{
    public override Product CreateProduct() { return new ConcreteProductB(); }
}
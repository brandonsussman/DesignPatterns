FurnitureFactory factory= new ComfortableFurnitureFactory();
Chair comfyChair = factory.createChair();
Bed comfyBed= factory.createBed();
factory = new UncomfortableFurnitureFactory();
Chair uncomfyChair= factory.createChair();  
Bed uncomfyBed = factory.createBed();
comfyBed.layDown();
comfyChair.sit();
uncomfyBed.layDown();
uncomfyChair.sit();
interface Chair
{
    public void sit();
}

interface Bed
{ 
    public void layDown(); 
}

public class ComfortableBed: Bed
{
    public void layDown()
    {
        Console.WriteLine("Lying on comfortable bed");
    }
}

public class UncomfortableBed : Bed
{
    public void layDown()
    {
        Console.WriteLine("Lying on uncomfortable bed");
    }
}
public class ComfortableChair : Chair
{
    public void sit()
    {
        Console.WriteLine("Sitting on comfortable Chair");
    }
}

public class UncomfortableChair:Chair
{
    public void sit()
    {
        Console.WriteLine("Sitting on uncomfortable Chair");
    }
}


abstract class FurnitureFactory 
{
    public abstract Chair createChair();

    public abstract Bed createBed();    

}


class ComfortableFurnitureFactory: FurnitureFactory
{
    public override Chair createChair()
    {
        return new ComfortableChair();  
    }
    public override Bed createBed()
    {
        return new ComfortableBed();
    }
}

class UncomfortableFurnitureFactory : FurnitureFactory
{
    public override Chair createChair()
    {
        return new UncomfortableChair();
    }
    public override Bed createBed()
    {
        return new UncomfortableBed();
    }
}
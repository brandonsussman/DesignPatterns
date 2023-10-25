SquarePeg squarePeg = new SquarePeg(3);
RoundPeg adaptedPeg = new SquaretoRoundPegAdapter(squarePeg);
RoundHole hole = new RoundHole(4);
hole.fits(adaptedPeg);

    public  class RoundPeg
{
   public int radius { get;  }
    public RoundPeg(int radius)
    {
        this.radius= radius;
    }

   

}

public class SquarePeg
{
    public int width { get; }

   public SquarePeg(int width) { this.width = width; }
}


public class SquaretoRoundPegAdapter: RoundPeg
{
    private SquarePeg squarePeg;
    public SquaretoRoundPegAdapter(SquarePeg squarePeg):base(squarePeg.width)
    {
        this.squarePeg = squarePeg;
    }

}


public class RoundHole
{
    public int radius { get; }
   public RoundHole(int radius) { this.radius = radius; }

   

    public void fits(RoundPeg peg)
    {
        if (radius >= peg.radius)
        {
            Console.WriteLine("fits");
        }
        else
        {
            Console.WriteLine("Doesn't fit");
        }
    }
}



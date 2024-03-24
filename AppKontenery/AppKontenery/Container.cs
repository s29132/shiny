namespace AppKontenery;

public abstract class Container
{
    public double LoadMass { protected set; get; }
    private double ownMass;
    protected double capacity;
    private double height;
    private double depth;
    private string serialNumber;
    private static int serialNumVal = 0;
    private char type;

    public Container(double ownMass, double capacity, double height, double depth)
    {
        this.LoadMass = 0;
        //this.loadMass = loadMass;
        this.ownMass = ownMass;
        this.capacity = capacity;
        this.height = height;
        this.depth = depth;
        this.serialNumber = "KON-" + type + "-" + serialNumber;
    }

    public abstract void EmptyLoad();

    public void LoadContainer(double mass)
    {
        if ((LoadMass + mass) > capacity)
        {
            throw new OverfillException($"Load of {mass} exceeds the container's capacity of {capacity}!");
        }

        LoadMass += mass;
    }
    protected static void PrintWarningMessage()
    {
        Console.WriteLine("Warning: This operation is unsafe! Aborting...");
    }
}
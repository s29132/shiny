namespace AppKontenery;

public abstract class Container
{
    public double LoadMass { protected set; get; }
    public double OwnMass { protected set; get; }
    protected double capacity;
    private double height;
    private double depth;
    public string SerialNumber { private set; get; }
    private static int serialNumVal = 0;
    protected char type;
    
    public Container(double ownMass, double capacity, double height, double depth)
    {
        this.LoadMass = 0;
        this.OwnMass = ownMass/1000;
        this.capacity = capacity/1000;
        this.height = height;
        this.depth = depth;
    }
    
    protected void SetSerialNumber()
    {
        this.SerialNumber = "KON-" + type + "-" + serialNumVal++;
    }

    public abstract void EmptyLoad();

    public void LoadContainer(double mass)
    {
        mass = mass / 1000;
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

    public override string ToString()
    {
        return
            $"Container's serial number: {SerialNumber}. Mass of an empty container: {OwnMass}. Container's capacity" +
            $" {capacity}. Container's height {height}. Container's depth: {depth}. Type of the container: {type}";
    }
}
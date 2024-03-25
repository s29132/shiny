namespace AppKontenery;

public class GContainer : Container, IHazardNotifier
{
    private double pressure;
    public GContainer(double ownMass, double capacity, double height, double depth, double pressure) : base(ownMass, capacity, height,
        depth)
    {
        this.pressure = pressure;
        this.type = 'G';
        SetSerialNumber();
    }
    public override void EmptyLoad()
    {
        LoadMass = LoadMass * 0.05;
    }

    public void SendHazardMessage(string serialNumber)
    {
        Console.WriteLine($"Hazard notification for container {serialNumber}");
    }

    public new void LoadContainer(double mass)
    {
        mass = mass / 1000;
        try
        {
            base.LoadContainer(mass);
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }
    }
}
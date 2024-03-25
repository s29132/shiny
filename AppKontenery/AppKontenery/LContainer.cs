namespace AppKontenery;

public class LContainer : Container, IHazardNotifier
{
    private bool _safe;

    public LContainer(double ownMass, double capacity, double height, double depth, bool safe) : base(ownMass, capacity, height, depth)
    {
        this._safe = safe;
        this.type = 'L';
        SetSerialNumber();
    }

    public bool Safe
    {
        get => _safe;
        set
        {
            if (LoadMass == 0)
            {
                Console.WriteLine($"Changing the status of the container to {_safe}");
                _safe = value;
            }
            else
            {
                Console.WriteLine("Container needs to be empty to change it's status!");
            }
        }
    }

    public void SendHazardMessage(string serialNumber)
    {
        Console.WriteLine($"Hazard notification for container {serialNumber}");
    }

    public override void EmptyLoad()
    {
        Console.WriteLine("Emptying the content of the container...");
        LoadMass = 0;
        Console.WriteLine("Container is empty.");
    }

    public new void LoadContainer(double mass)
    {
        mass = mass / 1000;
        if (_safe)
        {
            if ((LoadMass + mass) <= capacity*0.9)
            {
                LoadMass += mass;
            }
            else
            {
                PrintWarningMessage();
            }
        }
        else
        {
            if ((LoadMass + mass) <= capacity*0.5)
            {
                LoadMass += mass;
            }
            else
            {
                PrintWarningMessage();
            }
        }
    }
}
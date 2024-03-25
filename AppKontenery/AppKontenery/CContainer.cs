namespace AppKontenery;

public class CContainer : Container
{
    private double? temp;
    private Product productType;
    public CContainer(double ownMass, double capacity, double height, double depth, Product productType) : base(ownMass, capacity, height,
        depth)
    {
        this.productType = productType;
        this.temp = null;
        this.type = 'C';
        SetSerialNumber();
    }

    public override void EmptyLoad()
    {
        LoadMass = 0;
    }

    public new void LoadContainer(double mass, Product product)
    {
        mass = mass / 1000;
        if (temp == null)
        {
            Console.WriteLine("To load container you need to set temperature first!");
            return;
        }
        if (product.GetType() == productType.GetType())
        {
            if (product.RequiredTemp <= this.temp)
            {
                base.LoadContainer(mass);
            }
        }
        else
        {
                Console.WriteLine("Error, load type doesn't fit the requirements for the container!");
        }
    }

    public double? Temp
    {
        get => temp;
        set
        {
            if (productType.RequiredTemp <= value)
            {
                this.temp = value;
            }
            else
            {
                Console.WriteLine("Temperature is too low!");
            }
        }
    }
}
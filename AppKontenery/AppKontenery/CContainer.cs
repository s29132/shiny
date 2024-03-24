namespace AppKontenery;

public class CContainer : Container
{
    private double? _temp;
    private Product productType;
    public CContainer(double ownMass, double capacity, double height, double depth, Product productType) : base(ownMass, capacity, height,
        depth)
    {
        this.productType = productType;
        this._temp = null;
    }

    public override void EmptyLoad()
    {
        LoadMass = 0;
    }

    public new void LoadContainer(double mass, Product product)
    {
        if (_temp == null)
        {
            Console.WriteLine("To load container you need to set temperature first!");
            return;
        }
        if (product.GetType() == productType.GetType())
        {
            if (product.RequiredTemp <= this._temp)
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
        get => _temp;
        set
        {
            if (productType.RequiredTemp <= value)
            {
                this._temp = value;
            }
            else
            {
                Console.WriteLine("Temperature is too low!");
            }
        }
    }
}
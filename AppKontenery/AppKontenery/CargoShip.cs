using System.Collections;

namespace AppKontenery;

public class CargoShip
{
    public int CurrentNumOfContainers { get; }
    public double MaxSpeedInKnots { get; }
    public int MaxNumOfContainers { get;  }
    public double MaxLoadCapacityOfShipInTones { get; }
    private List<Container> containersOnShip;

    public CargoShip(double maxSpeedInKnots, int maxNumOfContainers, double maxLoadCapacityOfShipInTones)
    {
        this.CurrentNumOfContainers = 0;
        this.MaxSpeedInKnots = maxSpeedInKnots;
        this.MaxNumOfContainers = maxNumOfContainers;
        this.MaxLoadCapacityOfShipInTones = maxLoadCapacityOfShipInTones;
        this.containersOnShip = new List<Container>();
    }

    public void LoacContainer(Container container)
    {
        double currentWeight = 0;
        foreach (var c in containersOnShip)
        {
            currentWeight += c.LoadMass;
        }
        if (CurrentNumOfContainers < MaxNumOfContainers && currentWeight < MaxLoadCapacityOfShipInTones)
        {
            containersOnShip.Add(container);
        }
    }
    
}
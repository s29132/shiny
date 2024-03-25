using System.Collections;

namespace AppKontenery;

public class CargoShip
{
    public int CurrentNumOfContainers { get; private set; }
    public double MaxSpeedInKnots { get; }
    public int MaxNumOfContainers { get;  }
    public double MaxLoadCapacityOfShipInTones { get; }
    private double currentWeight;
    private List<Container> containersOnShip;

    public CargoShip(double maxSpeedInKnots, int maxNumOfContainers, double maxLoadCapacityOfShipInTones)
    {
        this.currentWeight = 0;
        this.CurrentNumOfContainers = 0;
        this.MaxSpeedInKnots = maxSpeedInKnots;
        this.MaxNumOfContainers = maxNumOfContainers;
        this.MaxLoadCapacityOfShipInTones = maxLoadCapacityOfShipInTones;
        this.containersOnShip = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
            if (CurrentNumOfContainers < MaxNumOfContainers &&
                (currentWeight + container.LoadMass + container.OwnMass) < MaxLoadCapacityOfShipInTones)
            {
                Console.WriteLine("Adding container");
                containersOnShip.Add(container);
                currentWeight += container.LoadMass + container.OwnMass;
                CurrentNumOfContainers += 1;
            }
    }
    
    public void LoadContainerList(List<Container> containers)
    {
        double containersWeight = 0;
        foreach (var cc in containers)
        {
            containersWeight += cc.LoadMass;
            containersWeight += cc.OwnMass;
        }
        
        if (CurrentNumOfContainers < MaxNumOfContainers && (currentWeight + containersWeight) < MaxLoadCapacityOfShipInTones)
        {
            foreach (var con in containers)
            {
                containersOnShip.Add(con);
                CurrentNumOfContainers += 1;
            }

            currentWeight += containersWeight;
        }
    }

    public int RemoveContainer(String serialNumOfContainer)
    {
        Container? container = SearchContainerBySerial(serialNumOfContainer);
        if (container == null)
        {
            Console.WriteLine("Couldn't find specified container.");
            return -1;
        }
        int indexToRemove = -1;
        for (int i = 0; i < containersOnShip.Count; ++i)
        {
            if (containersOnShip[i].GetType() == container.GetType())
            {
                indexToRemove = i;
                break;
            }
        }

        if (indexToRemove != -1)
        {
            containersOnShip.RemoveAt(indexToRemove);
            return 0;
        }

        return -1;
    }

    public void UnloadContainer(Container container)
    {
        container.EmptyLoad();
    }

    public void ReplaceContainer(Container containerToReplaceWith, string numOfContainerToReplace)
    {
        for (int i = 0; i < containersOnShip.Count; ++i)
        {
            if (containersOnShip[i].SerialNumber == numOfContainerToReplace)
            {
                containersOnShip[i] = containerToReplaceWith;
                break;
            }
            else
            {
                Console.WriteLine("Container is not present on the ship!");
            }
        }
    }

    public void MoveContainerToAnotherShip(CargoShip ship, string serialNumOfContainer)
    {
        Container? containerToMove = SearchContainerBySerial(serialNumOfContainer);
        if (containerToMove != null)
        {
            ship.LoadContainer(containerToMove);
        }
        else
        {
            Console.WriteLine("Cannot find specified container!");
        }
    }

    public Container? SearchContainerBySerial(string serialNum)
    {
        foreach (var con in containersOnShip)
        {
            if (con.SerialNumber == serialNum)
            {
                return con;
            }
        }

        return null;
    }
    
    public override string ToString()
    {
        return
            $"Ship's max speed in knots: {MaxSpeedInKnots}. Max capacity in tones: {MaxLoadCapacityOfShipInTones}. " +
            $"Max number of containers: {MaxNumOfContainers}. Current number of containers on the ship " +
            $"{CurrentNumOfContainers}. Current weight of the ship's load {currentWeight}";
    }

    public void reportShipContent()
    {
        if (containersOnShip.Count == 0)
        {
            Console.WriteLine("No containers on the ship to report!");
        }
        foreach (var c in containersOnShip)
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine(c);
            Console.WriteLine("===================================================================================");
        }
    }
    
}
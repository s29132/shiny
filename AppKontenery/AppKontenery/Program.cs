// See https://aka.ms/new-console-template for more information

using AppKontenery;

CargoShip cargoShip = new CargoShip(15, 112, 310);
LContainer container = new LContainer(51, 3011, 3000, 8000, true);
container.LoadContainer(100);
Console.WriteLine(container.LoadMass);
cargoShip.LoadContainer(container);
Console.WriteLine(cargoShip);
Console.WriteLine(container);
cargoShip.RemoveContainer("KON-L-0");
cargoShip.reportShipContent();
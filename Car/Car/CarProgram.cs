using System;
namespace Car
{
    class CarProgram
    {
        static void Main(string[] args)
        {

            Car myCar = new Car(25.0,0,0);

            Console.WriteLine("Fuel in tank: " + myCar.getFuel() + " litres.");
            Console.WriteLine("Total miles driven: " + myCar.getTotalMiles() + " miles.");

            myCar.printFuelCost();

            myCar.addFuel(10);

            Console.WriteLine("Fuel in tank: " + myCar.getFuel() + " litres.");

            myCar.drive(100);

            Console.WriteLine("Fuel in tank: " + myCar.getFuel() + " litres.");
            Console.WriteLine("Total miles driven: " + myCar.getTotalMiles() + " miles.");

            Console.ReadLine();
        }
    }
}

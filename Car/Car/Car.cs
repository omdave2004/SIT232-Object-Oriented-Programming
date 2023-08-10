namespace Car;
class Car
{
    // private fields to store the car's fuel efficiency, fuel in tank, and total miles driven
    private double fuelEfficiency;
    private double fuelInTank;
    private double totalMiles;

    // constant to hold the current cost of fuel in dollars per litre
    private const double FUEL_COST_PER_LITRE = 1.385;

    //public class 
    public Car(double fuelEfficiency,double fuelInTank,double totalMiles)
    {
        this.fuelEfficiency = fuelEfficiency;
        this.fuelInTank = 0;
        this.totalMiles = 0;
    }

    // accessor methods here
    public double getFuel()
    {
        return fuelInTank;
    }

    public double getTotalMiles()
    {
        return totalMiles;
    }

    public void setTotalMiles(double totalMiles)
    {
        this.totalMiles = totalMiles;
    }

    public void printFuelCost()
    {
        Console.WriteLine("The cost of fuel is: $" + string.Format("{0:0.00}", FUEL_COST_PER_LITRE));
    }

    // fuel addition
    public void addFuel(double litres)
    {
        fuelInTank += litres;
        Console.WriteLine("Added " + litres + " litres of fuel to the tank.");
        Console.WriteLine("The cost of this fill is: $" + string.Format("{0:0.00}", calcCost(litres)));
    }

    //cost calculation
    private double calcCost(double litres)
    {
        return litres * FUEL_COST_PER_LITRE;
    }

    //litre conversion
    private double convertToLitres(double gallons)
    {
        return gallons * 4.546;
    }

    //drive
    public void drive(double miles)
    {
        totalMiles += miles;
        double gallonsUsed = miles / fuelEfficiency;
        double litresUsed = convertToLitres(gallonsUsed);
        fuelInTank -= litresUsed;

        Console.WriteLine("You drove " + miles + " miles.");
        Console.WriteLine("You used " + string.Format("{0:0.00}", litresUsed) + " litres of fuel.");
        Console.WriteLine("The total cost of the journey is: $" + string.Format("{0:0.00}", calcCost(litresUsed)));
    }
}



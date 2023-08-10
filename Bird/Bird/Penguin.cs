public class Penguin : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Penguins cannot fly");
    }

    public override string ToString()
    {
        return "A penguin named " + base.Name;
    }
}

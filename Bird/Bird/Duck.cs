public class Duck : Bird
{
    public double Size { get; set; }
    public string Kind { get; set; }

    public override string ToString()
    {
        return "A duck named " + base.Name + " is a " + Size + " inch " + Kind;
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Bird> birds = new List<Bird>();

        Bird bird1 = new Bird();
        bird1.Name = "Feathers";
        Bird bird2 = new Bird();
        bird2.Name = "Polly";

        Duck duck1 = new Duck();
        duck1.Name = "Daffy";
        duck1.Size = 15;
        duck1.Kind = "Mallard";
        Duck duck2 = new Duck();
        duck2.Name = "Donald";
        duck2.Size = 20;
        duck2.Kind = "Decoy";

        Penguin penguin1 = new Penguin();
        penguin1.Name = "Happy Feet";
        Penguin penguin2 = new Penguin();
        penguin2.Name = "Gloria";

        birds.Add(bird1);
        birds.Add(bird2);
        birds.Add(penguin1);
        birds.Add(penguin2);
        birds.Add(duck1);
        birds.Add(duck2);

        foreach (Bird b in birds)
        {
            Console.WriteLine(b.ToString());
        }

        List<Duck> ducksToAdd = new List<Duck>()
        {
            duck1, duck2,
        };

        IEnumerable<Bird> upcastDucks = ducksToAdd;

        birds.Add(new Bird() { Name = "Feather" });

        birds.AddRange(upcastDucks);

        foreach (Bird b in birds)
        {
            Console.WriteLine(b.ToString());
        }

        Console.ReadLine();
    }
}

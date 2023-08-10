namespace DivisbleFour;
class Program
{
    static void Main(string[] args)
    {
        int user_input;
        //User input validation and getting the value from them
        Console.WriteLine("Enter the number for the upper value : ");

        user_input = int.Parse(Console.ReadLine());

        //Priting the statement above the loop
        Console.WriteLine("The numbers fulfilling the conditions are : ");

        //Simple loop the condition from for loop and putting the if condition
        for (int i = 1; i <= user_input; i++)
        {
            if (i % 4 == 0 && i % 5 != 0)
            {
                Console.WriteLine(i);
            }

        }
    }

}
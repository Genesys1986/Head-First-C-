// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Welcome to Hi-Lo!");
Console.WriteLine($"Guess the numbers between 1 and {HiLoGame.MAXIMUM}!");
HiLoGame.Hint();
while (HiLoGame.GetPot() > 0)
{
    Console.WriteLine("Press H for higher, L for lower, ? to buy a hint,");
    Console.WriteLine($"or any other key to quit with {HiLoGame.GetPot()}.");
    char key = Console.ReadKey(true).KeyChar;
    if (key == 'h' || key == 'H') HiLoGame.Guess(true);
    else if (key == 'l' || key == 'L') HiLoGame.Guess(false);
    else if (key == '?') HiLoGame.Hint();
    else return;
}

Console.WriteLine("The pot is empty. Bye!");

static class HiLoGame
{
    public const int MAXIMUM = 10;
    public static Random random = new Random();
    private static int currentNumber = random.Next(1, MAXIMUM +1);
    private static int pot = 10;

    public static int GetPot() { return pot; }

    public static void Guess(bool higher)
    {
        int nextNumber = random.Next(1,MAXIMUM +1);
        if (higher && nextNumber >= currentNumber || !higher && nextNumber <= currentNumber )
        {
            Console.Write("Congratulations, You guess right!");
            pot++;
        }
        else
        {
            Console.Write("Bad Luck, You guessed wrong.");
            pot--;
        }

        currentNumber = nextNumber; 
        Console.WriteLine("The current number is " + currentNumber);
        
        /*
        HiLoGame.random = new Random(1);
        Random seededRandom = new Random(1);
        Console.WriteLine("The first 20 numbers will be: ");
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine($"{seededRandom.Next(1, MAXIMUM + 1)}");
        } 
        */
        
        
    }

    public static void Hint()
    {
        int half = MAXIMUM / 2; 
        if (currentNumber >= half)
        {
            Console.WriteLine($"The number is at least {half}");
        }
        else
        {
            Console.WriteLine($"The number is at most {half}");
        }

        pot--;
    }
}
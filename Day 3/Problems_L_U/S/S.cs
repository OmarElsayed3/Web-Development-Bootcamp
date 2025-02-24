namespace S;

class S
{
    static void Main(string[] args)
    {
        float x = float.Parse(Console.ReadLine());
        
        if (x >= 0 && x <= 25)
            Console.WriteLine("Interval [0,25]");
        else if (x > 25 && x <= 50)
            Console.WriteLine("Interval (25,50]");
        else if (x > 50 && x <= 75)
            Console.WriteLine("Interval (50,75]");
        else if (x > 75 && x <= 100)
            Console.WriteLine("Interval (75,100]");
        else
            Console.WriteLine("Out of Intervals");
    }
}
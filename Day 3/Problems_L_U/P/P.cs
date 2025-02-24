namespace P;

class P
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        int digit = (int)input[0];
        Console.WriteLine((digit % 2 == 0) ? "EVEN" : "ODD");
    }
}
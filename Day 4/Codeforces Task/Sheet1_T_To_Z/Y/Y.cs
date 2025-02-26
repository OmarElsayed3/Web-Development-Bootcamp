namespace Y;

class Y
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        long num1 = long.Parse(input[0]);
        long num2 = long.Parse(input[1]);
        long num3 = long.Parse(input[2]);
        long num4 = long.Parse(input[3]);

        num1 %= 100;
        num2 %= 100;
        num3 %= 100;
        num4 %= 100;

        long result = num1 * num2 * num3 * num4;
        Console.WriteLine($"{(result / 10) % 10}{result % 10}");
    }
}
namespace K;

class K
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int num1 = int.Parse(input[0]);
        int num2 = int.Parse(input[1]);
        int num3 = int.Parse(input[2]);

        Console.WriteLine($"{Math.Min(num1, Math.Min(num2, num3))} {Math.Max(num1, Math.Max(num2, num3))}");

    }
}
namespace T;

class T
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        int num1 = int.Parse(input[0]);
        int num2 = int.Parse(input[1]);
        int num3 = int.Parse(input[2]);
        
        int mx = Math.Max(num1, Math.Max(num2, num3));
        int mn = Math.Min(num1, Math.Min(num2, num3));

        Console.WriteLine($"{mn}\n{num1 + num2 + num3 - mx - mn}\n{mx}\n");
        Console.WriteLine($"{num1}\n{num2}\n{num3}");
    }
}
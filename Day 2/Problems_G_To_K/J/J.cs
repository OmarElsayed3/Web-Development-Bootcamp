namespace J;

class J
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int num1 = int.Parse(input[0]);
        int num2 = int.Parse(input[1]);

        Console.WriteLine((num1 % num2 == 0 || num2 % num1 == 0) ? "Multiples" : "No Multiples");
    }
}
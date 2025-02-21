namespace I;

class I
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int num1 = int.Parse(input[0]);
        int num2 = int.Parse(input[1]);

        Console.WriteLine((num1 >= num2) ? "Yes" : "No");
    }
}
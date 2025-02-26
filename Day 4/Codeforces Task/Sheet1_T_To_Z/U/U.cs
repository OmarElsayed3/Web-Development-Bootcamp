namespace U;

class U
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        float num = float.Parse(input[0]);
        
        int num2 = (int)num;

        Console.WriteLine((num == num2) ? $"int {num}" : $"float {num2} {num - num2}");

    }
}
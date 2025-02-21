namespace H;

class H
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        double num1 = double.Parse(input[0]);
        double num2 = double.Parse(input[1]);
        var result = num1 / num2;
        
        Console.WriteLine($"floor {num1} / {num2} = {Math.Floor(num1 / num2)}");
        Console.WriteLine($"ceil {num1} / {num2} = {Math.Ceiling(num1 / num2)}");
        Console.WriteLine($"round {num1} / {num2} = {Math.Floor(result + 0.5)}");
        
    }
}
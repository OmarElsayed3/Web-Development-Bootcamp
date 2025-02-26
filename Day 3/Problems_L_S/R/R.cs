namespace R;

class R
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        
        int years = num / 365;
        int months = (num - years * 365) / 30;
        int days = num - years * 365 - months * 30;
        Console.WriteLine($"{years} years");
        Console.WriteLine($"{months} months");
        Console.WriteLine($"{days} days");
    }
}
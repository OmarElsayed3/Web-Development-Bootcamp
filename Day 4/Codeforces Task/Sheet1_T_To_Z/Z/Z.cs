namespace Z;

class Z
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        long a = long.Parse(input[0]);
        long b = long.Parse(input[1]);
        long c = long.Parse(input[2]);
        long d = long.Parse(input[3]);

        Console.WriteLine((b * Math.Log(a) > d * Math.Log(c)) ? "YES" : "NO");
    }
}
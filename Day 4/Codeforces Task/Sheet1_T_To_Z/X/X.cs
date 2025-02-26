namespace X;

class X
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int l1 = int.Parse(input[0]);
        int r1 = int.Parse(input[1]);
        int l2 = int.Parse(input[2]);
        int r2 = int.Parse(input[3]);
        
        int left=Math.Max(l1, l2);
        int right=Math.Min(r1, r2);

        Console.WriteLine(left > right ? -1 : $"{left} {right}");
    }
}
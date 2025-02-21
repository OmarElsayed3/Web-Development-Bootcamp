namespace G;

class G
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        long num = long.Parse(inputs[0]);
            
        Console.WriteLine(num*(num+1)/2);
    }
}
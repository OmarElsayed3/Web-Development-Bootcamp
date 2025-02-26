namespace Q;

class Q
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        
        double x = double.Parse(input[0]);
        double y = double.Parse(input[1]);
        
        if (y == 0 && x != 0)
            Console.WriteLine("Eixo X");
        else if (x == 0 && y != 0)
            Console.WriteLine("Eixo Y");
        else if (x == 0 && y == 0)
            Console.WriteLine("Origem");
        else
            Console.WriteLine((x > 0) ? ((y > 0) ? "Q1" : "Q4") : ((y > 0) ? "Q2" : "Q3"));
    }
}
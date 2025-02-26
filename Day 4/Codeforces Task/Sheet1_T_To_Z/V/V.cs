namespace V;

class V
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int num1 = int.Parse(input[0]);
        char ch = char.Parse(input[1]);
        int num2 = int.Parse(input[2]);
        switch (ch)
        {
            case '>':
                Console.WriteLine(num1 > num2 ? "Right" : "Wrong");
                break;
            case '<':
                Console.WriteLine(num1 < num2 ? "Right" : "Wrong");
                break;
            case '=':
                Console.WriteLine(num1 == num2 ? "Right" : "Wrong");
                break;
            
        }

    }
}
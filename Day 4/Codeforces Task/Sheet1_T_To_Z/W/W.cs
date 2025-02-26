namespace W;

class W
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int num1 = int.Parse(input[0]);
        char ch = char.Parse(input[1]);
        int num2 = int.Parse(input[2]);
        char ch2 = char.Parse(input[3]);
        int num3 = int.Parse(input[4]);
        switch (ch)
        {
            case '+':
                Console.WriteLine(num1 + num2 == num3 ? "Yes" : num1 + num2);   
                break;
            case '-':
                Console.WriteLine(num1 - num2 == num3 ? "Yes" : num1 - num2);   
                break;
            case '*':
                Console.WriteLine(num1 * num2 == num3 ? "Yes" : num1 * num2);   

                break;
            
        }

    }
}
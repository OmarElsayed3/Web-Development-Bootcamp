namespace O;

class O
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        char operation = ' ';
        foreach (var value in input)
        {
            if (value < '0')
            {
                operation = value;
                break;
            }
        }
        
        string[] nums = input.Split(operation);
        int num1 = int.Parse(nums[0]);
        int num2 = int.Parse(nums[1]);
        
        switch (operation)
        {
            case '+':
                Console.WriteLine(num1 + num2);
                break;
            case '-':
                Console.WriteLine(num1 - num2);
                break;
            case '*':
                Console.WriteLine(num1 * num2);
                break;
            case '/':
                Console.WriteLine(num1 / num2);
                break;
            
            
        }
    }
}
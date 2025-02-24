namespace N;

class N
{
    static void Main(string[] args)
    {
        char letter = char.Parse(Console.ReadLine());

        Console.WriteLine((letter >= 'a') ? letter.ToString().ToUpper() : letter.ToString().ToLower());
    }
}
namespace M;

class M
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        char letter = char.Parse(inputs[0]);


        Console.WriteLine((letter >= 65) ? ((letter >= 97) ? "ALPHA\nIS SMALL" : "ALPHA\nIS CAPITAL") : "IS DIGIT");

    }
}
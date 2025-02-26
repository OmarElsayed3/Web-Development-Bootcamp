namespace L
{
    internal class L
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string firstName1 = inputs[0];
            string lastName1 = inputs[1];
            
            string[] inputs2 = Console.ReadLine().Split(' ');
            string firstName2 = inputs2[0];
            string lastName2 = inputs2[1];

            Console.WriteLine((lastName1 == lastName2) ? "ARE Brothers" : "NOT");

        }
    }
}
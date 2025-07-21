
using System;

namespace ReflectionTask
{
    class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var source = new Source { Id = 1, Name = "Omar" };
            var destination = new Destination();

            Automapper.Map(source, destination);
            Console.WriteLine($"Id: {destination.Id}, Name: {destination.Name}");
            
            
        }
    }
}
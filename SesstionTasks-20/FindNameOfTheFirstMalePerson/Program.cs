
Queue<Tuple<string, char>> names = new Queue<Tuple<string, char>>();

names.Enqueue(new Tuple<string, char>("Alice", 'F'));
names.Enqueue(new Tuple<string, char>("Bob", 'M'));
names.Enqueue(new Tuple<string, char>("Charlie", 'M'));
names.Enqueue(new Tuple<string, char>("Diana", 'F'));

Console.WriteLine(names.GetFirstMaleName(name => name.Item2 == 'M'));
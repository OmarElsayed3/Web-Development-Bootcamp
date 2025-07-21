
Stack<string> names = new Stack<string>();
names.Push("Ali");
names.Push("Omar");
names.Push("Mohammed");
names.Push("Mohammed");
names.Push("Ahmed");

Console.WriteLine(names.GetFirstNameCallMohammed(name => name == "Mohammed"));

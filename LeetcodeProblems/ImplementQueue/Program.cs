using ImplementQueue;

QueueUsingStack<int> queueUsingStack = new QueueUsingStack<int>();

queueUsingStack.Enqueue(1);
queueUsingStack.Enqueue(2);
queueUsingStack.Enqueue(3);

Console.WriteLine(queueUsingStack.Dequeue()); 
Console.WriteLine(queueUsingStack.Dequeue()); 
Console.WriteLine(queueUsingStack.Dequeue()); 

Console.WriteLine(queueUsingStack.IsEmpty());
Console.WriteLine(queueUsingStack.Size());

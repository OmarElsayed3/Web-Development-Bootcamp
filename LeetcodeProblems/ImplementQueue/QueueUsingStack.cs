namespace ImplementQueue;

public class QueueUsingStack<T>
{
    private Stack<T> stack = new Stack<T>();
    private int _top;
    
    public QueueUsingStack()
    {
        _top = -1;
    }
    public void Enqueue(T x)
    {
        stack.Push(x);
        _top = stack.Count - 1;
    }
    public T Dequeue()
    {
        if (_top == -1)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        
        Stack<T> tempStack = new Stack<T>();
        while (stack.Count > 0)
        {
            tempStack.Push(stack.Pop());
        }

        T dequeuedValue = tempStack.Pop();
        
        while (tempStack.Count > 0)
        {
            stack.Push(tempStack.Pop());
        }

        return dequeuedValue;
    }
    public bool IsEmpty()
    {
        return _top == -1;
    }
    public int Size()
    {
        return stack.Count;
    }
}

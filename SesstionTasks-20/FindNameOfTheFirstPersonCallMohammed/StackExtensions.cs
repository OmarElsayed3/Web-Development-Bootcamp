
public static class StackExtensions
{
    public static string GetFirstNameCallMohammed(this Stack<string> stack, Predicate<string> isMohammed)
    {
        if (stack == null || stack.Count == 0)
        {
            return null;
        }
        foreach (var name in stack)
        {
            if (isMohammed(name))
            {
                return name;
            }
        }
        return null;
    }
}
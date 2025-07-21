
public static class QueueExtensions
{
    public static string GetFirstMaleName(this Queue<Tuple<string, char>> queue, Func<Tuple<string, char>, bool> isMale)
    {
        foreach (var item in queue)
        {
            if (isMale(item))
            {
                return item.Item1;
            }
        }
        return null;
    }
}
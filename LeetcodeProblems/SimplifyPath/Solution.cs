namespace SimplifyPath;

public class Solution
{
    public string SimplifyPath(string path)
    {
        string[] directories = path.Split('/');
        int top = 0;
        string[] stack = new string[directories.Length];
        foreach (string directory in directories)
        {
            if (directory == "." || directory == "")
            {
                continue;
            }
            else if (directory == "..")
            {
                if (top > 0)
                    top--;
                continue;
            }
            else
            {
                stack[top++] = directory;
            }
        }
        if (top == 0)
        {
            return "/";
        }
        return "/" + string.Join("/", stack, 0, top);
    }
}
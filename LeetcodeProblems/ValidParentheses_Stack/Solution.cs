namespace ValidParentheses_Stack;

public class Solution {
    public bool IsValid(string s) {
        char[] stack = new char[s.Length];
        int top = 0;
        if (s.Length % 2 == 1) 
            return false;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '(' || c == '{' || c == '[')
            {
                stack[top++] = c;
            }
            else
            {
                if (top == 0)
                    return false;
                char open = stack[top - 1];
                char close = (c == ')') ? (char)(c - 1) : (char)(c - 2);
                if (open != close)
                    return false;
                top--;
            }
        }
        return top == 0;
    }
}
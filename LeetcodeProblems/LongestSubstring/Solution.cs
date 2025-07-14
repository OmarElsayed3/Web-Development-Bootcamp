namespace LongestSubstring;

public class Solution
{
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char,bool> dict = new Dictionary<char,bool>();
        int left = 0;
        int maxLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            while (dict.ContainsKey(s[i]) && dict[s[i]])
            {
                dict[s[left]] = false;
                left++;
            }
            dict[s[i]] = true;
            maxLength = Math.Max(maxLength, i - left + 1);
        }
        return maxLength;
    }
}
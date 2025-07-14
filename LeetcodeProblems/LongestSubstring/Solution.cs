namespace LongestSubstring;

public class Solution
{
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> set = new HashSet<char>();
        int left = 0, maxLength = 0;
        for (int i = 0; i < s.Length; i++) {
            while (set.Contains(s[i])) {
                set.Remove(s[left]);
                left++;
            }
            set.Add(s[i]);
            maxLength = Math.Max(maxLength, i - left + 1);
        }
        return maxLength;
    }
}
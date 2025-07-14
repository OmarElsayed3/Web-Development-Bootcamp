namespace LinkedListToBinaryTree;

public class Solution : TreeNode
{
    public TreeNode Tree(int left, int right, List<int> values)
    {
        if (left > right)
            return null;
        int mid = (left + right) / 2;
        TreeNode node = new TreeNode(values[mid]);
        node.left = Tree(left, mid - 1, values);
        node.right = Tree(mid + 1, right, values);
        return node;
    }
    public TreeNode SortedListToBST(ListNode head)
    {
        List<int> values = new List<int>();
        while (head != null)
        {
            values.Add(head.val);
            head = head.next;
        }
        return Tree(0, values.Count - 1, values);
    }
}
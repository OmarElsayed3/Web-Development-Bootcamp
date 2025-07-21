namespace DFS;

public class TreeNode
{
    public int value;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int value)
    {
        this.value = value;
        left = null;
        right = null;
    }
    public void Insert(int value)
    {
        if (value < this.value)
        {
            if (left == null)
                left = new TreeNode(value);
            else
                left.Insert(value);
        }
        else
        {
            if (right == null)
                right = new TreeNode(value);
            else
                right.Insert(value);
        }
    }
    public int GetMinValue(TreeNode root)
    {
        if (root == null)
            throw new ArgumentNullException(nameof(root));

        int min = root.value;

        if (root.left != null)
            min = Math.Min(min, GetMinValue(root.left));
        if (root.right != null)
            min = Math.Min(min, GetMinValue(root.right));

        return min;
    }
    
}
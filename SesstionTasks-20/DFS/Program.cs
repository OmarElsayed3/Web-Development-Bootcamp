using DFS;

TreeNode root = new TreeNode(10);
root.Insert(5);
root.Insert(15);
root.Insert(3);
root.Insert(-7);
root.Insert(12);
root.Insert(-1);

Console.WriteLine(root.GetMinValue(root));



using LinkedListToBinaryTree;

ListNode head = new ListNode(-10, new ListNode(-3, new ListNode(0, new ListNode(5, new ListNode(9)))));

Solution solution = new Solution();
TreeNode root = solution.SortedListToBST(head);

root.PrintLevelOrder();
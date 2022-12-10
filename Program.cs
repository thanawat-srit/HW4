class Program
{
    static Tree<string> tree = new Tree<string>();
    static void Main(string[] args)
    {
        int rootChild = 1, startInput = -1;
        bool checkname = false, checkParent = false, vector = true;

        Input(rootChild, ref startInput, ref vector);

        check(tree.GetRoot(), Console.ReadLine(), ref checkParent, ref checkname);
    }
    static void Input(int x, ref int index, ref bool vector)
    {
        string name;
        int childNumber, currentIndex = index + 1;

        for (int i = 0; i < x; i++)
        {
            if (vector)
            {
                if (i == 0)
                {
                    name = Console.ReadLine();
                    tree.AddChild(index, name);
                    childNumber = int.Parse(Console.ReadLine());
                    index++;
                    Input(childNumber, ref index, ref vector);

                }
                else
                {
                    name = Console.ReadLine();
                    tree.AddSibling(index, name);
                    childNumber = int.Parse(Console.ReadLine());
                    index++;
                    Input(childNumber, ref index, ref vector);
                    vector = false;
                }
            }
            else
            {
                vector = true;
                name = Console.ReadLine();
                tree.AddSibling(currentIndex, name);
                childNumber = int.Parse(Console.ReadLine());
                index++;
                Input(childNumber, ref index, ref vector);
            }

        }
    }

    static void check(TreeNode<string> currentTreeNode, string name, ref bool checkParent, ref bool checkname)
    {
        TreeNode<string> ptr = currentTreeNode;

        if (name != ptr.GetValue())
        {
            if (ptr.Child() != null)
            {
                check(ptr.Child(), name, ref checkParent, ref checkname);
                checkParent = true;
            }
            if (ptr.Next() != null && checkname == false)
            {
                check(ptr.Next(), name, ref checkParent, ref checkname);
                checkParent = false;
            }
        }
        else
        {
            checkParent = false;
            checkname = true;
        }

        if (checkname)
        {
            if (checkParent)
            {
                Console.WriteLine(currentTreeNode.GetValue());
            }
            else
            {
                checkParent = true;
            }
        }
    }
}

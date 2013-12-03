namespace Tree
{
    using System;
    using System.Linq;

    public class TreeUtils
    {
        public static Tree<int> GenerateTreeFtomTreeNodes(TreeNode<int>[] nodeArray)
        {
            bool[] isChild = new bool[nodeArray.Length];
            foreach (var node in nodeArray)
            {
                if (node != null)
                {
                    foreach (var child in node)
                    {
                        isChild[child.Value] = true;
                    }
                } 
            }

            for (int i = 0; i < isChild.Length; i++)
			{
                if (!isChild[i])
                {
                    Tree<int> tree = new Tree<int>(i);
                    GenerateTreeFromFoor(tree, nodeArray);
                    return tree;
                }
			}

            throw new ArgumentException("No root!!!");
        }

        private static void GenerateTreeFromFoor(Tree<int> tree, TreeNode<int>[] nodeArray)
        {
            foreach (var node in nodeArray[tree.Root.Value])
            {
                tree.Root.AddChild(node);
                GenerateSubnodes(node, nodeArray);
            }
        }

        private static void GenerateSubnodes(TreeNode<int> node, TreeNode<int>[] nodeArray)
        {
            foreach (var subnode in nodeArray[node.Value])
            {
                node.AddChild(subnode);
                GenerateSubnodes(subnode, nodeArray);
            }
        }
    }
}

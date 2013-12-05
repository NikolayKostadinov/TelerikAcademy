namespace Tree
{
    using System;
    using System.Collections.Generic;
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

        public static List<AbstractTreeNode<int>> GetLeafs(AbstractTreeNode<int> tree)
        {
            List<AbstractTreeNode<int>> leafs = new List<AbstractTreeNode<int>>();
            foreach (AbstractTreeNode<int> node in tree)
            {
                if (node.GetChildCount() == 0)
                {
                    leafs.Add(node);
                }
                else
                {
                    leafs.AddRange(GetLeafs(node));
                }
            }

            return leafs;
        }

        public static List<AbstractTreeNode<int>> GetMiddleNodes(AbstractTreeNode<int> tree)
        {
            List<AbstractTreeNode<int>> leafs = new List<AbstractTreeNode<int>>();
            foreach (AbstractTreeNode<int> node in tree)
            {
                if (node.GetChildCount() > 0)
                {
                    leafs.Add(node);
                    leafs.AddRange(GetMiddleNodes(node));
                }
            }

            return leafs;
        }

        public static int GetLongestPathLenghtDFS(
            AbstractTreeNode<int> tree,
            Dictionary<string, int> paths,
            List<int> path)
        {
            if (tree.GetChildCount() == 0)
            {
                string key = string.Join(", ", path);
                if (!paths.ContainsKey(key))
                {
                    paths.Add(key, path.Count);
                }

                path.RemoveAt(path.Count - 1);
                return 0;
            }

            int maxPath = 0;

            foreach (var node in tree)
            {
                path.Add(node.Value);
                maxPath = Math.Max(maxPath, GetLongestPathLenghtDFS(node, paths, path));
            }

            path.RemoveAt(path.Count - 1);
            return maxPath + 1;
        }

        private static void GenerateTreeFromFoor(Tree<int> tree, TreeNode<int>[] nodeArray)
        {
            foreach (TreeNode<int> node in nodeArray[tree.Root.Value])
            {
                tree.Root.AddChild(node);
                GenerateSubnodes(node, nodeArray);
            }
        }

        private static void GenerateSubnodes(TreeNode<int> node, TreeNode<int>[] nodeArray)
        {
            foreach (TreeNode<int> subnode in nodeArray[node.Value])
            {
                node.AddChild(subnode);
                GenerateSubnodes(subnode, nodeArray);
            }
        }
    }
}

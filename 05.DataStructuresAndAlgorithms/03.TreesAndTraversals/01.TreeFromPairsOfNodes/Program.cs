namespace TreeFromPairsOfNodes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tree;

    public class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                TreeNode<int>[] nodes = GetNodesFtomConsole();
                Tree<int> tree = TreeUtils.GenerateTreeFtomTreeNodes(nodes);

                // 01. Find root
                Console.WriteLine("Root Of Tree is: " + tree.Root.Value);

                // 02. Find Leafs
                List<AbstractTreeNode<int>> leafs = TreeUtils.GetLeafs(tree);
                Console.WriteLine(
                    "The Leaves of tree {0}: {1}",
                    (leafs.Count > 1) ? "are" : "is",
                    string.Join(", ", leafs));

                // 03. Fing middle Nodes
                List<AbstractTreeNode<int>> middleNodes = TreeUtils.GetMiddleNodes(tree);
                Console.WriteLine(
                    "The Middle nodes of tree {0}: {1}",
                    (leafs.Count > 1) ? "are" : "is", 
                    string.Join(", ", middleNodes));

                // 04. Get The LongestPath in the tree
                Dictionary<string, int> paths = new Dictionary<string, int>();
                List<int> rootName = new List<int>() { tree.Root.Value };
                int maxPathLenght = TreeUtils.GetLongestPathLenghtDFS(tree, paths, rootName);
                Console.WriteLine("The longest path in tree is long: {0}", maxPathLenght);
                ConsolePrintLongestPath(paths, maxPathLenght + 1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ConsolePrintLongestPath(Dictionary<string, int> paths, int lenghtOfLongestPath)
        {
            int index = 0; 

            foreach (var path in paths)
            {
                if (path.Value == lenghtOfLongestPath)
                {
                    index++;
                    Console.Write("Longest path {0} ==> ", index);
                    Console.WriteLine(path.Key);
                }
            }
        }

        private static TreeNode<int>[] GetNodesFtomConsole()
        {
            int nodeCount = 0;
            bool isAValidNumber = int.TryParse(Console.ReadLine(), out nodeCount);

            if (!isAValidNumber || nodeCount < 0)
            {
                throw new ArgumentException("You have to enter a valid positive integer for number of nodes!");
            }

            TreeNode<int>[] nodes = new TreeNode<int>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }

            for (int i = 1; i <= nodeCount - 1; i++)
            {
                var pair = ReadPareFromConsole();

                int parentId = pair.Item1;
                int childId = pair.Item2;

                nodes[parentId].AddChild(new TreeNode<int>(childId));
            }

            return nodes;
        }

        private static Tuple<int, int> ReadPareFromConsole()
        {
            string inputString = Console.ReadLine();
            var splitString = inputString.Split(' ');

            if (splitString.Length < 2)
            {
                throw new ArgumentException("The pair must be entered in qurrent format (parent child)");
            }

            int parent = CheckIfNumber(splitString[0], "Parent");
            int child = CheckIfNumber(splitString[1], "Child");
            Tuple<int, int> descriptor = new Tuple<int, int>(parent, child);

            return descriptor;
        }

        private static int CheckIfNumber(string inString, string messageParam)
        {
            int output = 0;
            bool isNumber = int.TryParse(inString, out output);
            if (!isNumber || output < 0)
            {
                throw new ArgumentException("{0} index must be positive number!!!", messageParam);
            }

            return output;
        }
    }
}

namespace TreeFromPairsOfNodes
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TreeNode<int>[] nodes = GetNodesFtomConsole();
                Tree<int> tree = TreeUtils.GenerateTreeFtomTreeNodes(nodes);
                Console.WriteLine("Root Of Tree is: " + tree.Root.Value);
                Console.WriteLine(tree);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
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

            for (int i = 1; i <= nodeCount-1; i++)
            {
                var pair = ReadPareFromConsole();

                int parentId = pair.Item1;
                int childId = pair.Item2;

                nodes[parentId].AddChild(new TreeNode<int>(childId));
            }

            return nodes;
        }
  
        private static Tuple<int,int> ReadPareFromConsole()
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

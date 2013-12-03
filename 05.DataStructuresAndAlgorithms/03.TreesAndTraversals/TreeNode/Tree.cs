namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T>: IEnumerable<TreeNode<T>>
    {
        private TreeNode<T> root;

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public Tree(T value) 
        {
            this.root = new TreeNode<T>(value);
        }

        public TreeNode<T> Root
        {
            get { return this.root; }
        }

        public override string ToString()
        {
            return this.TraverseDFSToString(this.root, string.Empty);
        }

        private string TraverseDFSToString(TreeNode<T> root, string spaces)
        {
            
            if (this.root == null)
            {
                return string.Empty;
            }
            
            StringBuilder result = new StringBuilder();
            result.Append(spaces);
            result.Append(root.Value);
            result.Append("\n");

            foreach (var child in root)
            {
                result.Append(TraverseDFSToString(child, spaces + "   "));
            }

            return result.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // TODO: Implement this method
            return GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            // TODO: Implement this method
            foreach (TreeNode<T> node in this.root)
            {
                yield return node;
            }
        }
    }
}

namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeNode<T> : AbstractTreeNode<T>
    {
        private T value;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public override T Value
        {
            get
            {
                return this.value;
            }
        }

        public override int GetChildCount()
        {
            return this.children.Count;
        }

        public void AddChild(TreeNode<T> child)
        {
            this.children.Add(child);
        }

        public TreeNode<T> this[int index]
        {
            get
            {
                return this.children[index];
            }
        }

        public override IEnumerator<AbstractTreeNode<T>> GetEnumerator()
        {
            // TODO: Implement this method
            foreach (TreeNode<T> node in this.children)
            {
                yield return node;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}

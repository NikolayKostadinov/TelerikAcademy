namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeNode<T> : IEnumerable<TreeNode<T>>
    {
        private T value;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            // TODO: Implement this method
            return GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            // TODO: Implement this method
            foreach (TreeNode<T> node in this.children)
            {
                yield return node;
            }
        }
    }
}

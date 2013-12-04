namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class AbstractTreeNode<T> : System.Collections.Generic.IEnumerable<AbstractTreeNode<T>>, ITree
    {
        public abstract T Value{get;}
        public abstract IEnumerator<AbstractTreeNode<T>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract int GetChildCount();
    }
}

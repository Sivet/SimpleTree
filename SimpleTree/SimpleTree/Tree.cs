using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTree
{
    class Tree
    {
        private TreeNode rootNode;

        public void RecursiveAddToTree(int data)
        {
            if (this.rootNode == null)
            {
                this.rootNode = new TreeNode { Data = data };
            }
            else
            {
                this.RecursiveAddToTree(this.rootNode, new TreeNode() { Data = data });
            }


        }
        private void RecursiveAddToTree(TreeNode current, TreeNode toAdd)
        {
            if (toAdd.Data.CompareTo(current.Data) <= 0)
            {
                if (current.Left == null)
                    current.Left = toAdd;
                else
                    RecursiveAddToTree(current.Left, toAdd);
            }
            else
            {
                if (current.Right == null)
                    current.Right = toAdd;
                else
                    RecursiveAddToTree(current.Right, toAdd);
            }
        }
        public void RemoveFromTree(int data)
        {
            RemoveFromTree(data, rootNode);
        }
        private void RemoveFromTree(int data, TreeNode current)
        {
            //laver en null reference når den tjekker en gren som er null.
            if (current == null)
                return;
            else
            {
                if (current.Left.Data == data)
                {
                    current.Left = current.Left.Left;
                }
                if (current.Right.Data == data)
                {
                    current.Right = current.Right.Right;
                }
                if (data < current.Data)
                {
                    RemoveFromTree(data, current.Left);
                }
                if (data > current.Data)
                {
                    RemoveFromTree(data, current.Right);
                }
                
            }
        }
    }
}

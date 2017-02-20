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
    }
}

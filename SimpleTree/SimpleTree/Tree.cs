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

        public void AddToTree(IComparable data)
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
        public bool RemoveFromTree(IComparable data)
        {
            if (rootNode.Data.CompareTo(data) == 0)
            {
                return false;
            }
            if (data.CompareTo(rootNode.Data) > 0)
            {
                if (rootNode.Right == null)
                {
                    return false;
                }
                return RecursiveRemoveFromTree(data, rootNode.Right, rootNode);
            }
            if (data.CompareTo(rootNode.Data) < 0)
            {
                if (rootNode.Left == null)
                {
                    return false;
                }
                return RecursiveRemoveFromTree(data, rootNode.Left, rootNode);
            }
            return false;
        }
        private bool RecursiveRemoveFromTree(IComparable data, TreeNode current, TreeNode before)
        {
            TreeNode Min;
            if (current == null) { return false; }

            else if (data.CompareTo(current.Data) < 0)
                RecursiveRemoveFromTree(data, current.Left, current);//look in the left
            else if (data.CompareTo(current.Data) > 0)
                RecursiveRemoveFromTree(data, current.Right, current);//look in the right
            else //found node to delete
            {
                if (current.Left != null && current.Right != null)//two children
                {
                    Min = FindMinium(current.Right);
                    current.Data = Min.Data;
                    RecursiveRemoveFromTree(current.Data, current.Right, current);
                    return true;
                }
                else //one or zero children
                {
                    if (current.Left == null) //if child might be on the right
                    {
                        if (current.Right != null) //child is on the right
                        {
                            if (before.Data.CompareTo(current.Data) > 0)
                            {
                                before.Left = current.Right;
                            }
                            else
                            {
                                before.Right = current.Right;
                            }
                        }
                        else // if no children
                        {
                            if (current.Data.CompareTo(before.Data) > 0)
                            {
                                before.Right = null;
                            }
                            else
                            {
                                before.Left = null;
                            }
                        }
                    }
                    else if (current.Right == null) //if child might be on the left
                    {
                        if (current.Left != null) //if child is on the left
                        {
                            if (before.Data.CompareTo(current.Data) > 0)
                            {
                                before.Left = current.Left;
                            }
                            else
                            {
                                before.Right = current.Left;
                            }
                        }
                        else //if no children
                        {
                            if (current.Data.CompareTo(before.Data) > 0)
                            {
                                before.Right = null;
                            }
                            else
                            {
                                before.Left = null;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private TreeNode FindMinium(TreeNode node)
        {
            if (rootNode == null)
                return null;
            else if (node.Left == null)
                return node;
            else
                return FindMinium(node.Left);

        }
        private TreeNode FindMaximum(TreeNode node)
        {
            if (rootNode == null)
                return null;
            else if (node.Right == null)
                return node;
            else
                return FindMinium(node.Right);
        }
        public TreeNode FindNode(IComparable data)
        {
            if (rootNode == null)
            {
                return null;
            }
            else
            {
                return FindNode(data, rootNode);
            }
            
        }
        private TreeNode FindNode(IComparable data, TreeNode current)
        {
            if (rootNode == null)
                return null;
            else if (data.CompareTo(current.Data) < 0)
                FindNode(data, current.Left);//look in the left
            else if (data.CompareTo(current.Data) > 0)
                FindNode(data, current.Right);//look in the right
            else
            {//found node
                return current;
            }
            return null;
        }
    }
}

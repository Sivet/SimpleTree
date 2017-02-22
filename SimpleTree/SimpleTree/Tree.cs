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

        public void AddToTree(int data)
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
        public bool RemoveFromTree(int data)
        {
            if (rootNode.Data == data)
            {
                return false;
            }
            if (data > rootNode.Data)
            {
                if (rootNode.Right == null)
                {
                    return false;
                }
                return RecursiveRemoveFromTree(data, rootNode.Right, rootNode);
            }
            if (data < rootNode.Data)
            {
                if (rootNode.Left == null)
                {
                    return false;
                }
                return RecursiveRemoveFromTree(data, rootNode.Left, rootNode);
            }
            return false;
        }
        private bool RecursiveRemoveFromTree(int data, TreeNode current, TreeNode before)
        {
            TreeNode Min;
            if (current == null) { return false; }

            else if (data < current.Data)
                RecursiveRemoveFromTree(data, current.Left, current);//look in the left
            else if (data > current.Data)
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
                            if (before.Data > current.Data)
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
                            if (current.Data > before.Data)
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
                            if (before.Data > current.Data)
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
                            if (current.Data > before.Data)
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
        public TreeNode FindNode(int data)
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
        private TreeNode FindNode(int data, TreeNode current)
        {
            if (rootNode == null)
                return null;
            else if (data < current.Data)
                FindNode(data, current.Left);//look in the left
            else if (data > current.Data)
                FindNode(data, current.Right);//look in the right
            else
            {//found node
                return current;
            }
            return null;
        }
        //public void delete(TreeNode Tree, int Tar)
        //{

        //    TreeNode Min, Temp;
        //    if (Tree == null) { return; }

        //    else if (Tar < Tree.Data) delete(Tree.Left, Tar);//look in the left
        //    else if (Tar > Tree.Data) delete(Tree.Right, Tar);//look in the right
        //    else
        //    { //found node to delete

        //        if (Tree.left != null && Tree.right != null) //two children
        //        {
        //            Min = findmin(Tree.right);
        //            Tree.data = Min.data;
        //            delete(Tree.right, Tree.Data);

        //        }

        //        else
        //        { //one or zero child

        //            if (Tree.left == null)
        //            {
        //                if (Tree.parent == null)
        //                    Root = Tree.right; //The root node is to be deleted.
        //                else
        //                {
        //                    if (Tree.right != null)
        //                    {
        //                        Tree.right.parent = Tree.parent;
        //                    }

        //                    if (Tree == Tree.parent.left)
        //                        Tree.parent.left = Tree.right;
        //                    else Tree.parent.right = Tree.right;
        //                }

        //            }
        //            else if (Tree.right == null)
        //            {
        //                if (Tree.parent == null) Root = Tree.left;

        //                else
        //                {

        //                    Tree.left.parent = Tree.parent;
        //                    if (Tree == Tree.parent.left)
        //                        Tree.parent.left = Tree.left;
        //                    else Tree.parent.right = Tree.left;
        //                }
        //            }



        //        }

        //    }

        //}
    }
}

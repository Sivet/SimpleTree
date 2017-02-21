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
            if (current.Data == data)
            {
                int dataRight = -1;
                if (current.Right != null)
                    dataRight = current.Right.Data;
                int dataLeft = -1;
                if (current.Left != null)
                    dataLeft = current.Left.Data;

                if (current.Right == null) // hvis den ene undergren er null
                {
                    if (current.Left == null) // hvis begge er null
                    {
                        if (before.Left == current) // hvis tidligere grens Left er den vi står på
                        {
                            before.Left = current.Left; // fjern os fra undergrenen
                            current.Left = null;
                            return true;
                        }
                        before.Right = current.Right; // ellers fjern os fra Right
                        current.Right = null;
                        return true;
                    }
                    // hvis kun Right er null
                    if (before.Right == current) // hvis tidligere grens Right er den vi står på
                    {

                        before.Right = current.Right; // fjern os fra undergrenen
                        current.Right = null;
                        return true;
                    }
                    before.Left = current.Left; // ellers fjern os fra Right
                    current.Left = null;
                    return true;
                }
                else if (current.Left == null) // hvis kun Left på vores geren er null
                {
                    if (before.Left == current) // hvis tidligere grens Left er den vi står på
                    {
                        before.Left = current.Right; // fjern os fra undergrenen
                        current.Right = null;
                        return true;
                    }
                    before.Right = current.Right; // ellers fjern os fra Right
                    current.Right = null;
                    return true;
                }
                else // hvis vi har noget i begge undergrene
                {
                    if (before.Right == current)
                    {
                        before.Right = current.Right;
                        //before.Right.Left = currenctBranch.Left;
                        RecursiveAddToTree(current.Left, before.Right); // tilføj venstre gren igen
                        current.Right = null;
                        current.Left = null;
                        return true;
                    }
                    before.Left = current.Right;
                    //before.Left.Left = currenctBranch.Left;
                    RecursiveAddToTree(current.Left, before.Left);
                    current.Right = null;
                    current.Left = null;
                    return true;
                }
            }
            if (data > current.Data)
            {
                if (current.Right == null)
                {
                    return false;
                }
                return RecursiveRemoveFromTree(data, current.Right, current);
            }
            if (data < current.Data)
            {
                if (current.Left == null)
                {
                    return false;
                }
                return RecursiveRemoveFromTree(data, current.Left, current);
            }
            return false;
        }
        public void RecursiveRemoveFromTree2(int data, TreeNode current, TreeNode before)
        {
            TreeNode Min;
            if (current == null) { return; }

            else if (data < current.Data) RecursiveRemoveFromTree2(data, current.Left, current);//look in the left
            else if (data > current.Data) RecursiveRemoveFromTree2(data, current.Right, current);//look in the right
            else
            {//found node to delete
                if (current.Left != null && current.Right != null)//two children
                {
                    Min = FindMinium(current.Right);
                    current.Data = Min.Data;
                    RecursiveRemoveFromTree2(data, current.Right, current);
                }
                else
                { //one or zero children
                    if (current.Left == null)
                    {
                        if (before == null) //the root node is to be deleted
                        {
                            rootNode = current.Right;
                        }
                        //else
                        //{
                        //    if (Tree.right != null)
                        //    {
                        //        Tree.right.parent = Tree.parent;
                        //    }

                        //    if (Tree == Tree.parent.left)
                        //        Tree.parent.left = Tree.right;
                        //    else Tree.parent.right = Tree.right;
                        //}
                    }
                    else if (current.Right == null)
                    {
                        if (before == null)
                            rootNode = current.Left;

                        else
                        {
                            //Tree.left.parent = Tree.parent;
                            if (current == before.Left)
                                before.Left = current.Left;
                            else before.Right = current.Left;
                        }
                    }
                }
            }
        }
        public TreeNode FindMinium(TreeNode node)
        {
            if (rootNode == null)
                return null;
            else if (node.Left == null)
                return node;
            else
                return FindMinium(node.Left);
            
        }
        public TreeNode FindMaximum(TreeNode node)
        {
            if (rootNode == null)
                return null;
            else if (node.Right == null)
                return node;
            else
                return FindMinium(node.Right);
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

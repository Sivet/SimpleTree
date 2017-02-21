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
    }
}

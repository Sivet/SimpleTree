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
            TreeNode currentNode = rootNode;
            TreeNode Node = new TreeNode();
            Node.Data = data;

            if (rootNode == null)
            {
                rootNode = Node;
                return;
            }
            
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Data < data)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = Node;
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.Left;
                        }

                    }
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = Node;
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                    return;
                }
                
            }
        }
    }
}

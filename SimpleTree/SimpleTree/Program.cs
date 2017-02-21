using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.AddToTree(2);
            tree.AddToTree(4);
            tree.AddToTree(7);
            tree.AddToTree(1);
            tree.AddToTree(5);
            tree.AddToTree(8);
            tree.AddToTree(15);
            tree.AddToTree(3);
            tree.AddToTree(6);

            tree.RemoveFromTree(15);
            tree.RemoveFromTree(3);

        }
    }
}

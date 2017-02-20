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
            tree.RecursiveAddToTree(2);
            tree.RecursiveAddToTree(4);
            tree.RecursiveAddToTree(7);
            tree.RecursiveAddToTree(1);
            tree.RecursiveAddToTree(5);
            tree.RecursiveAddToTree(8);
            tree.RecursiveAddToTree(15);
            tree.RecursiveAddToTree(3);
            tree.RecursiveAddToTree(6);

            tree.RemoveFromTree(15);
            tree.RemoveFromTree(3);

        }
    }
}

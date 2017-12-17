using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDistance
{
    class Program
    {
        public virtual int findDistance(Node root, int n1, int n2)
        {
            int x = Pathlength(root, n1) - 1;
            int y = Pathlength(root, n2) - 1;
            int lcaData = findLCA(root, n1, n2).data;
            int lcaDistance = Pathlength(root, lcaData) - 1;
            return (x + y) - 2 * lcaDistance;
        }

        public virtual int Pathlength(Node root, int n1)
        {
            if (root != null)
            {
                int x = 0;
                if ((root.data == n1) || (x = Pathlength(root.left, n1)) > 0 || (x = Pathlength(root.right, n1)) > 0)
                {
                    // System.out.println(root.data);
                    return x + 1;
                }
                return 0;
            }
            return 0;
        }

        public virtual Node findLCA(Node root, int n1, int n2)
        {
            if (root != null)
            {
                if (root.data == n1 || root.data == n2)
                {
                    return root;
                }
                Node left = findLCA(root.left, n1, n2);
                Node right = findLCA(root.right, n1, n2);

                if (left != null && right != null)
                {
                    return root;
                }
                if (left != null)
                {
                    return left;
                }
                if (right != null)
                {
                    return right;
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            Node root = new Node(5);
            root.left = new Node(3);
            root.right = new Node(6);
            root.left.left = new Node(1);
            root.left.right = new Node(2);
            root.right.left = new Node(4);
            //root.right.right = new Node(35);
            //root.left.right.right = new Node(45);
            Program i = new Program();
            Console.WriteLine("Distance between 2 and 4 is : " + i.findDistance(root, 2, 4));
            Console.ReadLine();
        }
    }
    internal class Node
    {
        internal int data;
        internal Node left;
        internal Node right;

        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }

}

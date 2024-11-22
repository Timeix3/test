using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Node
    {
        public int Index { get; set; }
        public int LowerBorder { get; set; }
        public int UpperBorder { get; set; }
        public List<Node> Childrens { get; set; }
        public Node(int index)
        {
            Childrens = new();
            Parent = parent;
            Index = index;
        }
        public static void Print(Node root)
        {
            Console.Write($"{root.Index}. {root.LowerBorder} - {root.UpperBorder}\n");
            foreach (var item in root.Childrens)
            {
                Print(item);
            }
        }
        public static Node Find(Node root, int index)
        {
            if (root.Index == index) return root;
            foreach (var item in root.Childrens)
            {
                Node node = Find(item, index);
                if (node != null) return node;
            }
            return null;
        }
        public static bool CheckCompatible(Node root)
        {
            List<int> lowerBorders = new();
            List<int> upperBorders = new();
            CalcMax(root, lowerBorders);
            CalcMin(root, upperBorders);
            for(int i = 0; i < lowerBorders.Count; i++)
            {
                Console.WriteLine($"{lowerBorders[i]} <= {upperBorders[i]}");
                if (lowerBorders[i] > upperBorders[i]) return false;
            }
            return true;
        }
        static int CalcMax(Node node, List<int> lowerBorders)
        {
            int value;
            if (node.Childrens.Count != 0) value = Math.Max(node.LowerBorder, node.Childrens.Sum(node=>CalcMax(node, lowerBorders)));
            else value = node.LowerBorder;
            lowerBorders.Add(value);
            return value;
        }
        static int CalcMin(Node node, List<int> upperBorders)
        {
            int value;
            if (node.Childrens.Count != 0) value = Math.Min(node.UpperBorder, node.Childrens.Sum(node=>CalcMin(node, upperBorders)));
            else value = node.UpperBorder;
            upperBorders.Add(value);
            return value;
        }
    }
}

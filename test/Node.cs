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
            Index = index;
        }
        public static void Print(Node source)
        {
            Console.Write($"{source.Index}. {source.LowerBorder} - {source.UpperBorder}\n");
            foreach (var item in source.Childrens)
            {
                Print(item);
            }
        }
        public static Node Find(Node source, int index)
        {
            if (source.Index == index) return source;
            foreach (var item in source.Childrens)
            {
                Node node = Find(item, index);
                if (node != null) return node;
            }
            return null;
        }
        public static bool CheckCompatible(Node source)
        {
            List<int> lowerBorders = new();
            List<int> upperBorders = new();
            CalcMax(source, lowerBorders);
            CalcMin(source, upperBorders);
            for(int i = 0; i < lowerBorders.Count; i++)
            {
                if (lowerBorders[i] > upperBorders[i]) return false;
            }
            return true;
        }
        static int CalcMax(Node node, List<int> lowerBorders)
        {
            int value;
            if (node.Childrens.Count != 0) value = Math.Max(node.LowerBorder, node.Childrens.Sum(node => CalcMax(node, lowerBorders)));
            else value = node.LowerBorder;
            lowerBorders.Add(value);
            return value;
        }
        static int CalcMin(Node node, List<int> upperBorders)
        {
            int value;
            if (node.Childrens.Count != 0) value = Math.Min(node.UpperBorder, node.Childrens.Sum(node => CalcMin(node, upperBorders)));
            else value = node.UpperBorder;
            upperBorders.Add(value);
            return value;
        }
    }
}

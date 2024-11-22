using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Node
    {
        int Index { get; set; }
        int LowerBorder { get; set; }
        int UpperBorder { get; set; }
        public int CurrentValue { get; set; }
        public List<Node> Childrens { get; set; }
        Node Parent { get; set; }
        public Node(Node parent, int index)
        {
            Childrens = new();
            Parent = parent;
            Index = index;
        }
        public void SetBorders(int lowerBorder, int upperBorder)
        {
            LowerBorder = lowerBorder;
            UpperBorder = upperBorder;
            CurrentValue = lowerBorder;
        }
        public static void AddResource(Node node)
        {
            node.Parent.CurrentValue = node.Parent.Childrens.Sum(child => child.CurrentValue);
            int resourceToAdd = node.UpperBorder - node.LowerBorder;
            if (node.Parent.CurrentValue + resourceToAdd <= node.Parent.UpperBorder)
                node.CurrentValue += resourceToAdd;
            else do
                {
                    resourceToAdd--;
                    if (node.Parent.CurrentValue + resourceToAdd <= node.Parent.UpperBorder)
                    { node.CurrentValue += resourceToAdd; break; }
                } while (resourceToAdd > 1);
        }
        public static void PrintJobs(Node source)
        {
            if (source.Childrens.Count == 0)
                Console.Write($"{source.Index}. A={source.LowerBorder} B={source.UpperBorder} X={source.CurrentValue}\n");
            foreach (var item in source.Childrens)
            {
                PrintJobs(item);
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


namespace PlanningTask
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
        public void AddResource()
        {
            Parent.CurrentValue = Parent.Childrens.Sum(child => child.CurrentValue);
            int resourceToAdd = UpperBorder - LowerBorder;
            do
            {
                if (Parent.CurrentValue + resourceToAdd <= Parent.UpperBorder)
                { CurrentValue += resourceToAdd; break; }
                resourceToAdd--;
            } while (resourceToAdd > 1);
        }
        public static void PrintJobs(Node source, Dictionary<int, int> profit)
        {
            if (source.Childrens.Count == 0)
                Console.Write($"{source.Index}. A={source.LowerBorder} B={source.UpperBorder} X={source.CurrentValue} C={profit[source.Index]}\n");
            foreach (var item in source.Childrens)
            {
                PrintJobs(item, profit);
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

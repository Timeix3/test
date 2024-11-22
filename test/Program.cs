using test;

internal class Program
{
    private static void Main()
    {
        Node root = new Node(0);
        string[] lines = File.ReadAllLines("C:\\Users\\User\\source\\repos\\test\\test\\data.txt");
        for(int i = 0; i < lines.Length/3; i++)
        {
            int index = int.Parse(lines[i * 3]);
            Node node = Node.Find(root, index);
            if (lines[3 * i + 1] != "-")
            foreach (var item in lines[i * 3 + 1].Split())
                node.Childrens.Add(new Node(int.Parse(item)));
            node.LowerBorder = int.Parse(lines[i * 3 + 2].Split().First());
            node.UpperBorder = int.Parse(lines[i * 3 + 2].Split().Last());
        }
        Node.Print(root);
        Console.WriteLine(Node.CheckCompatible(root));
    }
}
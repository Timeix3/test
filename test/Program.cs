using System;
using System.Collections;
using System.Collections.Generic;
using test;

internal class Program
{
    private static void Main()
    {
        Node source = new Node(null, 0);
        string[] lines = File.ReadAllLines("C:\\Users\\User\\source\\repos\\test\\test\\data.txt");
        for(int i = 0; i < lines.Length/3; i++)
        {
            int index = int.Parse(lines[i * 3]);
            Node node = Node.Find(source, index);
            if (lines[3 * i + 1] != "-")
            foreach (var item in lines[i * 3 + 1].Split())
                node.Childrens.Add(new Node(node, int.Parse(item)));
            node.SetBorders(int.Parse(lines[i * 3 + 2].Split().First()), int.Parse(lines[i * 3 + 2].Split().Last()));
        }
        Dictionary<int, int> stonks = new()
        {
            [3] = 8,
            [4] = 6,
            [5] = 12,
            [6] = 7,
            [7] = 4,
            [8] = 3
        };
        stonks = stonks.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        int criteria = 0;
        foreach (var item in stonks)
        {
            Node node = Node.Find(source, item.Key);
            Node.AddResource(node);
            criteria += node.CurrentValue * item.Value;
        }
        Console.WriteLine(criteria);
        Node.PrintJobs(source);
        Console.WriteLine(Node.CheckCompatible(source));
    }
}
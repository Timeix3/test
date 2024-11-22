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
        Dictionary<int, int> stonks = new();
        for (int i = 0; i < lines.Length/3; i++)
        {
            int index = int.Parse(lines[i * 3]);
            Node node = Node.Find(source, index);
            if (lines[3 * i + 1].Split().First() != "-")
            foreach (var item in lines[i * 3 + 1].Split())
                node.Childrens.Add(new Node(node, int.Parse(item)));
            else stonks.Add(index, int.Parse(lines[3 * i + 1].Split().Last()));
            node.SetBorders(int.Parse(lines[i * 3 + 2].Split().First()), int.Parse(lines[i * 3 + 2].Split().Last()));
        }

        stonks = stonks.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        if (Node.CheckCompatible(source)) Console.WriteLine("Система совместна");
        else { Console.WriteLine("Система несовместна"); Environment.Exit(0); }
        int criteria = 0;
        foreach (var item in stonks)
        {
            Node node = Node.Find(source, item.Key);
            node.AddResource();
            criteria += node.CurrentValue * item.Value;
        }
        Console.WriteLine($"Критерий = {criteria}");
        Node.PrintJobs(source);
    }
}
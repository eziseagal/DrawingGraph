using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < t; i++)
            {
                string type = Console.ReadLine();
                int n = int.Parse(Console.ReadLine());

                string dotType = GetDotType(type);

                output.AppendLine($"{dotType} {{");

                for (int j = 0; j < n; j++)
                {
                    string[] edge = Console.ReadLine().Split();
                    string node1 = edge[0];
                    string node2 = edge[1];
                    string weight = (type == "gw" || type == "dw") ? $" [label = {edge[2]}]" : "";

                    output.AppendLine($"{node1} {(dotType == "graph" ? "--" : "->")} {node2}{weight};");
                }

                output.AppendLine("}");
            }

            Console.WriteLine(output);
        }

        static string GetDotType(string type) => type switch
        {
            "g" => "graph",
            "d" => "digraph",
            "gw" => "graph",
            "dw" => "digraph",
            _ => throw new ArgumentException("Nieprawidłowy rodzaj grafu.")
        };
    }
}
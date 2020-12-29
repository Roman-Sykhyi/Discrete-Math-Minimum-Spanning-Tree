using System;

namespace MinimumSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            SpanningTree spanningTree = new SpanningTree();
            
            spanningTree.FindMinimumSpanningTree();
            
            Console.WriteLine("Мінімальне кістякове дерево:");
            foreach (var treeEdge in spanningTree.TreeEdges)
            {
                Console.WriteLine(treeEdge.Name + ", вага - " + treeEdge.Weight);
            }
            
            Console.WriteLine($"\nВага мінімального кістякового дерева - {spanningTree.GetTreeWeight()}");
            
            Console.ReadKey();
        }
    }
}

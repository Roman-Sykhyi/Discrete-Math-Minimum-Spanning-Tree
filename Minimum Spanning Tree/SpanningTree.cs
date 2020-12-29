using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MinimumSpanningTree
{
    class SpanningTree
    {
        public Graph Graph;

        public List<Edge> TreeEdges;
        public List<Point> TreePoints;

        private List<Edge> edgesToCheck;

        public void FindMinimumSpanningTree() 
        { 
            TreePoints.Add(Graph.Points[0]);

            while (true)
            {
                var edge = FindNextEdge();

                if (edge == null) 
                    break;
                
                TreeEdges.Add(edge);
                
                TreePoints.Add(edge.EndPoint);
                TreePoints.Add(edge.StartPoint);
                TreePoints = TreePoints.Distinct().ToList();

                edgesToCheck.Remove(edge);

                RemoveUnecessaryEdges();
            }
        }

        private Edge FindNextEdge()
        {
            List<Edge> edges = new List<Edge>();

            // знаходимо всі ребра початковою точкою яких є одна з вершин кістякового дерева
            foreach (var point in TreePoints)
            {
                foreach (var edge in edgesToCheck)
                {
                    if (edge.StartPoint == point || edge.EndPoint == point) //&& !TreeEdges.Contains(edge))
                    {
                        edges.Add(edge);
                    }
                }
            }

            // серед знайдених ребер вибираємо ребро з найменшою вагою
            if (edges.Count == 0)
                return null;
            
            var resultEdge = edges[0];
            foreach (var edge1 in edges)
            {
                if (edge1.Weight < resultEdge.Weight)
                    resultEdge = edge1;
            }
            
            return resultEdge;
        }

        private void RemoveUnecessaryEdges()
        {
            List<Edge> edgesToRemove = new List<Edge>();
            
            foreach (var edge in edgesToCheck)
            {
                foreach (var treePoint1 in TreePoints)
                {
                    foreach (var treePoint2 in TreePoints)
                    {
                        if ((edge.StartPoint == treePoint1 && edge.EndPoint == treePoint2)
                            || (edge.EndPoint == treePoint1 && edge.StartPoint == treePoint2))
                        {
                            edgesToRemove.Add(edge);
                        }
                    }
                }
            }

            foreach (var edge in edgesToRemove)
            {
                edgesToCheck.Remove(edge);
            }
        }

        public int GetTreeWeight()
        {
            int result = 0;

            foreach (Edge edge in TreeEdges)
            {
                result += edge.Weight;
            }
            
            return result;
        } 

        public SpanningTree()
        {
            Graph = new Graph();

            TreeEdges = new List<Edge>();
            TreePoints = new List<Point>();
            edgesToCheck = new List<Edge>();

            Edge[] edgesToCheckArr = new Edge[Graph.Edges.Count];
            Graph.Edges.CopyTo(edgesToCheckArr);
            edgesToCheck = edgesToCheckArr.ToList<Edge>();
        }
    }
}

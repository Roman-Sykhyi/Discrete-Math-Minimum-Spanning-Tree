using System;
using System.Collections.Generic;
using System.Text;

namespace MinimumSpanningTree
{
    class Edge
    {
        public Point StartPoint;
        public Point EndPoint;

        public int Weight;

        public string Name;

        public Edge(Point startPoint, Point endPoint, int weight)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Weight = weight;
            
            Name = StartPoint.Name + "-" + EndPoint.Name;
        }
    }
}

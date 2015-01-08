using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph {

    public class Graph<T> {

        public class Vertex {

            public T Value { get; set; }
            public List<Edge> Edges { get; set; }

            public Vertex(T value) {
                Value = value;
                Edges = new List<Edge>();
            }

            public override string ToString() {
                string edges = String.Join(", ", Edges.Select(e => e.ToString()));
                return String.Format("({0}{1})", Value, String.IsNullOrEmpty(edges) ? "" : ": " + edges);
            }

        }

        public class Edge {

            public int Weight { get; set; }
            public Vertex Vertex { get; set; }

            public Edge(Vertex vertex, int weight) {
                Vertex = vertex;
                Weight = weight;
            }

            public override string ToString() {
                return Vertex.Value + (Weight > int.MinValue ? "{" + Weight + "}" : "");
            }

        }

        public Dictionary<T, Vertex> Vertices { get; set; }

        public Graph() {
            Vertices = new Dictionary<T, Vertex>();
        }

        public void AddVertex(T value) {
            Vertices.Add(value, new Vertex(value));
        }

        public void AddEdge(T from, T to, bool bidirectional = true) {
            AddEdge(from, to, int.MinValue, bidirectional);
        }

        public void AddEdge(T from, T to, int weight, bool bidirectional = true) {
            if(!Vertices.ContainsKey(from) || !Vertices.ContainsKey(to)) {
                throw new ArgumentException("Trying to add edge between non-existing vertices!");
            }

            var fromVertex = Vertices[from];
            var toVertex = Vertices[to];

            fromVertex.Edges.Add(new Edge(toVertex, weight));

            if(bidirectional) {
                toVertex.Edges.Add(new Edge(fromVertex, weight));
            }
        }

        public IList<T> DepthFirstSearch(T from, T to) {
            if(!Vertices.ContainsKey(from) || !Vertices.ContainsKey(to)) {
                throw new ArgumentException("Trying to search path between non-existing vertices!");
            }

            Vertex fromVertex = Vertices[from];
            Vertex toVertex = Vertices[to];

            var visited = new HashSet<Vertex>();
            var path = new Dictionary<Vertex, Vertex>();

            if(DepthFirstSearch(fromVertex, toVertex, visited, path)) {
                return RestorePath(fromVertex, toVertex, path);
            }   

            return null;
        }

        private bool DepthFirstSearch(Vertex vertex, Vertex toVertex, HashSet<Vertex> visited, Dictionary<Vertex, Vertex> path) {
            if(vertex == toVertex)
                return true;

            visited.Add(vertex);

            foreach(var edge in vertex.Edges) {
                if(visited.Contains(edge.Vertex))
                    continue;

                path[edge.Vertex] = vertex;

                if(DepthFirstSearch(edge.Vertex, toVertex, visited, path))
                    return true;
            }

            return false;
        }

        public IList<T> BreadthFirstSearch(T from, T to) {
            if(!Vertices.ContainsKey(from) || !Vertices.ContainsKey(to)) {
                throw new ArgumentException("Trying to search path between non-existing vertices!");
            }

            Vertex fromVertex = Vertices[from];
            Vertex toVertex = Vertices[to];

            var visited = new HashSet<Vertex>();
            var path = new Dictionary<Vertex, Vertex>();
            var queue = new Queue<Vertex>();
            visited.Add(fromVertex);
            queue.Enqueue(fromVertex);

            while(queue.Count > 0) {
                var vertex = queue.Dequeue();
                
                if(vertex == toVertex) {
                    return RestorePath(fromVertex, toVertex, path);
                }

                foreach(var edge in vertex.Edges) {
                    if(visited.Contains(edge.Vertex))
                        continue;

                    path[edge.Vertex] = vertex;
                    visited.Add(edge.Vertex);
                    queue.Enqueue(edge.Vertex);
                }
            }

            return null;
        }

        private IList<T> RestorePath(Vertex fromVertex, Vertex toVertex, Dictionary<Vertex, Vertex> path) {
            var result = new List<T>();

            Vertex vertex = toVertex;
            while(vertex != fromVertex) {
                result.Insert(0, vertex.Value);
                vertex = path[vertex];
            }
            result.Insert(0, vertex.Value);

            return result;
        }

        public override string ToString() {
            var result = new StringBuilder();

            foreach(var vertex in Vertices.Values) {
                result.Append(vertex.ToString());
            }

            return result.ToString();
        }

    }

}

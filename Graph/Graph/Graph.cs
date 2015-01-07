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

        public override string ToString() {
            var result = new StringBuilder();

            foreach(var vertex in Vertices.Values) {
                result.Append(vertex.ToString());
            }

            return result.ToString();
        }

    }

}

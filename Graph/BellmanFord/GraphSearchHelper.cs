using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace BellmanFord {

    public class WrongGraphException: Exception {

        public WrongGraphException(string message)
            : base(message) { }

    }

    public class GraphSearchHelper<T> {

        private class Edge {

            public Graph<T>.Vertex Vertex { get; set; }
            public Graph<T>.Vertex ToVertex { get; set; }
            public int Weight { get; set; }

            public Edge(Graph<T>.Vertex vertex, Graph<T>.Edge edge) {
                Vertex = vertex;
                ToVertex = edge.Vertex;
                Weight = edge.Weight;
            }

        }

        private readonly Graph<T> _graph;

        private Graph<T> Graph {
            get { return _graph; }
        }

        public Dictionary<T, Graph<T>.Vertex> Vertices {
            get { return Graph.Vertices; }
        }

        private List<Edge> _edges;
        private List<Edge> Edges {
            get {
                if(_edges == null) {
                    _edges = Vertices.Values.SelectMany(v => v.Edges.Select(e => new Edge(v, e))).ToList();
                }
                return _edges;
            }
        }

        public GraphSearchHelper(Graph<T> graph) {
            _graph = graph;
        }
        
        public IList<T> BellmanFordSearch(T from, T to) {
            if(!Vertices.ContainsKey(from) || !Vertices.ContainsKey(to)) {
                throw new ArgumentException("Trying to search path between non-existing vertices!");
            }

            var fromVertex = Vertices[from];
            var toVertex = Vertices[to];

            var distance = new Dictionary<Graph<T>.Vertex, int>();
            var path = new Dictionary<Graph<T>.Vertex, Graph<T>.Vertex>();

            foreach(var vertex in Vertices.Values) {
                distance[vertex] = vertex == fromVertex ? 0 : int.MaxValue;
                path[vertex] = null;
            }

            foreach(var vertex in Vertices.Values) {
                foreach(var edge in Edges) {
                    if(distance[edge.ToVertex] > distance[edge.Vertex] + edge.Weight) {
                        distance[edge.ToVertex] = distance[edge.Vertex] + edge.Weight;
                        path[edge.ToVertex] = edge.Vertex;
                    }
                }
            }

            CheckForNegativeCycles(distance);

            return RestorePath(path, fromVertex, toVertex);

        }

        private void CheckForNegativeCycles(Dictionary<Graph<T>.Vertex, int> distance) {
            foreach(var edge in Edges) {
                if(distance[edge.Vertex] + edge.Weight < distance[edge.ToVertex])
                    throw new WrongGraphException("Graph contains negative-weight cycle!");
            }
        }

        private IList<T> RestorePath(Dictionary<Graph<T>.Vertex, Graph<T>.Vertex> path, Graph<T>.Vertex fromVertex, Graph<T>.Vertex toVertex) {
            var result = new List<T>();

            var vertex = toVertex;
            while(vertex != fromVertex) {
                result.Insert(0, vertex.Value);
                vertex = path[vertex];
            }
            result.Insert(0, vertex.Value);

            return result;
        }

    }

}

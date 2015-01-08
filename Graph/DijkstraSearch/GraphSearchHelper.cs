using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace DijkstraSearch {

    public class GraphSearchHelper<T> {

        private readonly Graph<T> _graph;

        public Graph<T> Graph {
            get { return _graph; }
        }

        public Dictionary<T, Graph<T>.Vertex> Vertices {
            get { return Graph.Vertices; }
        }

        public GraphSearchHelper(Graph<T> graph) {
            _graph = graph;
        }

        private Dictionary<Graph<T>.Vertex, int> Distance { get; set; }
        private Dictionary<Graph<T>.Vertex, Graph<T>.Vertex> Path { get; set; }
        private List<Graph<T>.Vertex> Queue { get; set; }

        public IList<T> DijkstraSearch(T from, T to) {
            if(!Vertices.ContainsKey(from) || !Vertices.ContainsKey(to)) {
                throw new ArgumentException("Trying to search path between non-existing vertices!");
            }

            var fromVertex = Vertices[from];
            var toVertex = Vertices[to];
            var visited = new HashSet<Graph<T>.Vertex>();

            Distance = new Dictionary<Graph<T>.Vertex, int>();
            Path = new Dictionary<Graph<T>.Vertex, Graph<T>.Vertex>();
            Queue = new List<Graph<T>.Vertex>();
            
            Distance[fromVertex] = 0;
            Queue.Add(fromVertex);

            while(Queue.Count > 0) {
                var vertex = TakeNearestVertex();
                visited.Add(vertex);

                if(vertex == toVertex)
                    return RestorePath(fromVertex, toVertex);

                foreach(var edge in vertex.Edges) {
                    if(visited.Contains(edge.Vertex)) 
                        continue;

                    int distanceToVertex = Distance[vertex] + edge.Weight;

                    if(IsDistanceLessThanExisting(edge.Vertex, distanceToVertex)) {
                        Distance[edge.Vertex] = distanceToVertex;
                        Path[edge.Vertex] = vertex;
                    }
                    
                    Queue.Add(edge.Vertex);
                }
            }

            return null;
        }

        private Graph<T>.Vertex TakeNearestVertex() {
            Graph<T>.Vertex result = null;
            int minDistance = int.MaxValue;

            foreach(var vertex in Queue) {
                if(Distance[vertex] < minDistance) {
                    minDistance = Distance[vertex];
                    result = vertex;
                }
            }

            Queue.Remove(result);
            return result;
        }

        private bool IsDistanceLessThanExisting(Graph<T>.Vertex vertex, int distanceToVertex) {
            if(!Distance.ContainsKey(vertex))
                return true;
            return Distance[vertex] > distanceToVertex;
        }

        private IList<T> RestorePath(Graph<T>.Vertex fromVertex, Graph<T>.Vertex toVertex) {
            var result = new List<T>();

            var vertex = toVertex;
            while(vertex != fromVertex) {
                result.Insert(0, vertex.Value);
                vertex = Path[vertex];
            }
            result.Insert(0, vertex.Value);

            return result;
        }

    }

}

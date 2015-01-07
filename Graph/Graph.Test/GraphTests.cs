using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graph.Test {

    [TestClass]
    public class GraphTests {

        [TestMethod]
        public void AddVerticesAndEdgesToGraphTest() {
            // arrange
            var graph = new Graph<int>();

            // act
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddEdge(1, 2, false);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3, 10);

            // assert
            Assert.AreEqual("(1: 2, 3)(2: 3{10})(3: 1, 2{10})(4)", graph.ToString());
        }

        [TestMethod]
        public void BreadthFirstSearchInGraphTest() {
            // arrange
            var graph = new Graph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(5, 7);

            // act
            IList<int> path = graph.BreadthFirstSearch(1, 7);

            // assert
            Assert.AreEqual("1 -> 2 -> 3 -> 5 -> 7", String.Join(" -> ", path));
        }

    }

}

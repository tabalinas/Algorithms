using System;
using System.Collections.Generic;
using Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DijkstraSearch.Test {

    [TestClass]
    public class DijkstraSearchTests {

        [TestMethod]
        public void DijkstraSearchTest() {
            // arrange
            var graph = new Graph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddEdge(1, 2, 10);
            graph.AddEdge(2, 3, 10);
            graph.AddEdge(3, 4, 20);
            graph.AddEdge(3, 5, 20);
            graph.AddEdge(4, 6, 20);
            graph.AddEdge(6, 7, 10);
            graph.AddEdge(5, 7, 40);

            // act
            IList<int> path = new GraphSearchHelper<int>(graph).DijkstraSearch(1, 7);

            // assert
            Assert.AreEqual("1 -> 2 -> 3 -> 4 -> 6 -> 7", String.Join(" -> ", path));
        }

    }

}

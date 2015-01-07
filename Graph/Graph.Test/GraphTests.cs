﻿using System;
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

    }

}

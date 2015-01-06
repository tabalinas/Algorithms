using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueensProblem.Test {

    [TestClass]
    public class QueenAllocatorTests {

        [TestMethod]
        public void Locate4QueensTest() {
            // arrange
            var boardSize = 4;
            var expectedSolutions = new HashSet<BoardSquare>[] {
                new HashSet<BoardSquare>() { new BoardSquare(1, 2), new BoardSquare(2, 4), new BoardSquare(3, 1), new BoardSquare(4, 3) },
                new HashSet<BoardSquare>() { new BoardSquare(1, 3), new BoardSquare(2, 1), new BoardSquare(3, 4), new BoardSquare(4, 2) }
            };

            // act
            var result = new QueenAllocator(boardSize).Locate();

            // assert
            var solutions = result.ToArray();
            for(int i = 0; i < solutions.Length; i++) {
                CollectionAssert.AreEqual(solutions[i].ToList(), expectedSolutions[i].ToList());
            }
        }

    }

}

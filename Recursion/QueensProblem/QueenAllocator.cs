using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensProblem {

    /// <summary>
    /// Place n chess queens on an n×n chessboard so that no two queens threaten each other
    /// </summary>
    public class QueenAllocator {

        private readonly int _size;

        public int Size {
            get { return _size; }
        }

        public QueenAllocator(int size) {
            _size = size;
        }

        private HashSet<HashSet<BoardSquare>> _result;

        public HashSet<HashSet<BoardSquare>> Locate() {
            _result = new HashSet<HashSet<BoardSquare>>();

            PlaceQueen(new HashSet<BoardSquare>(), 1);

            return _result;
        }

        private void PlaceQueen(HashSet<BoardSquare> allocation, int row) {
            if(row > Size) {
                _result.Add(allocation);
                return;
            }

            for(int col = 1; col <= Size; col++) {
                var location = new BoardSquare(row, col);

                if(IsLocationAllowed(allocation, location)) {
                    var allocationWithQueen = new HashSet<BoardSquare>(allocation);
                    allocationWithQueen.Add(location);
                    PlaceQueen(allocationWithQueen, row + 1);
                }
            }
        }

        private bool IsLocationAllowed(HashSet<BoardSquare> allocation, BoardSquare location) {
            var result = true;

            foreach(var square in allocation) {
                if(location.Row == square.Row || location.Col == square.Col || IsSameDiagonal(square, location))
                    return false;
            }

            return result;
        }

        private bool IsSameDiagonal(BoardSquare sq1, BoardSquare sq2) {
            return Math.Abs(sq1.Col - sq2.Col) == Math.Abs(sq1.Row - sq2.Row);
        }

    }

}

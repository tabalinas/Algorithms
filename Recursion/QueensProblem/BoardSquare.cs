using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensProblem {

    public struct BoardSquare {

        private int _row;
        private int _col;
        
        public int Row {
            get { return _row; }
        }

        public int Col {
            get { return _col; }
        }

        public BoardSquare(int row, int col) {
            _row = row;
            _col = col;
        }

    }

}

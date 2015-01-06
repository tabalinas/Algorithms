using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParenthesesValidPairs {

    public class ParenthesesGenerator {

        private HashSet<string> _result;

        public HashSet<string> Generate(int amount) {
            _result = new HashSet<string>();

            Generate("", amount, amount);

            return _result;
        }

        private void Generate(string parentheses, int openedAmount, int closedAmount) {
            if(openedAmount == 0 && closedAmount == 0) {
                _result.Add(parentheses);
                return;
            }

            if(openedAmount > 0) {
                Generate(parentheses + "(", openedAmount - 1, closedAmount);
            }

            if(closedAmount > openedAmount) {
                Generate(parentheses + ")", openedAmount, closedAmount - 1);
            }
        }
    }

}

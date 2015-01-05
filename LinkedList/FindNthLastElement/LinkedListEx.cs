using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace FindNthLastElement {

    public static class LinkedListEx {

        public static T FindLast<T>(this LinkedList<T> list, int n) {
            LinkedList<T>.Node result = null;

            var current = list.Head;
            for(int i = 1; current != null; current = current.Next, i++) {
                if(i < n)
                    continue;

                result = (i == n) ? list.Head : result.Next;
            }

            return result != null ? result.Value : default(T);
        }

    }

}

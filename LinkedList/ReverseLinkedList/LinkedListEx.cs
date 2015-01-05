using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace ReverseLinkedList {

    public static class LinkedListEx {

        public static void Reverse<T>(this LinkedList<T> list) {
            if(list.Head == null)
                return;

            list.Reverse(list.Head);
        }

        private static void Reverse<T>(this LinkedList<T> list, LinkedList<T>.Node node) {
            var next = node.Next;

            if(next == null) {
                list.Head = node;
            } else {
                list.Reverse(next);
                next.Next = node;
            }

            node.Next = null;
        }

    }

}

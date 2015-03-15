using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace ReverseLinkedList {

    public static class LinkedListEx {

        public static void Reverse<T>(this LinkedList<T> list) {
            list.Head = Reverse(list.Head);
        }

        private static LinkedList<T>.Node Reverse<T>(LinkedList<T>.Node node) {
            if(node == null)
                return null;

            if(node.Next == null)
                return node;

            var next = node.Next;
            node.Next = null;

            var result = Reverse(next);
            next.Next = node;

            return result;
        }

    }

}

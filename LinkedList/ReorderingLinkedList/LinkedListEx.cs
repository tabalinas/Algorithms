using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace ReorderingLinkedList {

    /// <summary>
    /// Reorder linked list elements as (1) -> (N) -> (2) -> (N-1) ... -> (i) -> (N-i-1) e.g. 1->2->3->4->5 becomes 1->5->2->4->3
    /// </summary>
    public static class LinkedListEx {

        public static void Reorder<T>(this LinkedList<T> list) {
            var firstHalf = list.Head;
            
            var middle = list.Middle();
            CutOfFirstHalf(list, middle);
            var secondHalf = Reverse(middle);

            Merge(list, firstHalf, secondHalf);
        }

        public static LinkedList<T>.Node Middle<T>(this LinkedList<T> list) {
            var slow = list.Head;
            var fast = list.Head;

            while(fast != null && fast.Next != null) {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }

        private static void CutOfFirstHalf<T>(LinkedList<T> list, LinkedList<T>.Node middle) {
            var current = list.Head;
            while(current.Next != middle) {
                current = current.Next;
            }
            current.Next = null;
        }

        public static LinkedList<T>.Node Reverse<T>(LinkedList<T>.Node node) {
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

        private static void Merge<T>(LinkedList<T> list, LinkedList<T>.Node firstHalf, LinkedList<T>.Node secondHalf) {
            var first = firstHalf;
            var second = secondHalf;
            list.Head = new LinkedList<T>.Node(default(T));
            var current = list.Head;

            while(first != null || second != null) {
                if(first != null) {
                    current.Next = first;
                    first = first.Next;
                    current = current.Next;
                }

                if(second != null) {
                    current.Next = second;
                    second = second.Next;
                    current = current.Next;
                }
            }

            list.Head = list.Head.Next;
        }

    }

}

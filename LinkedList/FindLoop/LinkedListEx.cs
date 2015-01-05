using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace FindLoop {

    public static class LinkedListEx {

        public static T FindLoop<T>(this LinkedList<T> list) {
            var meetNode = list.FindFastSlowMeetNode();

            if(meetNode == null)
                return default(T);

            var loopNode = (meetNode == list.Head)
                ? list.FindLastNode()
                : list.FindLoopNode(meetNode);

            return loopNode.Value;
        }

        private static LinkedList<T>.Node FindFastSlowMeetNode<T>(this LinkedList<T> list) {
            var slow = list.Head;
            var fast = list.Head;

            while(fast != null && fast.Next != null) {
                slow = slow.Next;
                fast = fast.Next.Next;

                if(slow == fast)
                    return slow;
            } 

            return null;
        }

        private static LinkedList<T>.Node FindLastNode<T>(this LinkedList<T> list) {
            var result = list.Head;

            while(result.Next != list.Head) {
                result = result.Next;
            }

            return result;
        }

        private static LinkedList<T>.Node FindLoopNode<T>(this LinkedList<T> list, LinkedList<T>.Node meetNode) {
            var result = meetNode;
            var current = list.Head;

            while(result.Next != current.Next) {
                result = result.Next;
                current = current.Next;
            }

            return result;
        }

    }

}

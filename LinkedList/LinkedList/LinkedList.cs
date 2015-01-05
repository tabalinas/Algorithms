using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList {

    public class LinkedList<T> {

        public class Node {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value) {
                Value = value;
            }
        }

        public Node Head { get; set; }

        public LinkedList(T[] items) {
            Insert(items);
        }

        private void Insert(Node node) {
            if(Head == null) {
                Head = node;
                return;
            }

            var current = Head;
            while(current.Next != null) {
                current = current.Next;
            }
            current.Next = node;
        }

        public void Insert(T item) {
            Insert(new Node(item));
        }

        public void Insert(T[] items) {
            if(items == null || items.Length == 0)
                return;

            var node = new Node(items[0]);
            Insert(node);

            for(int i = 1; i < items.Length; i++) {
                node.Next = new Node(items[i]);
                node = node.Next;
            }
        }

        public bool Remove(T value) {
            if(Head == null)
                return false;

            if(Head.Value.Equals(value)) {
                Head = Head.Next;
                return true;
            }

            for(Node prev = Head, current = Head.Next; current != null; prev = current, current = current.Next) {
                if(current.Value.Equals(value)) {
                    prev.Next = current.Next;
                    return true;
                }
            }

            return false;
        }

        public Node Find(T value) {
            for(Node current = Head; current != null; current = current.Next) {
                if(current.Value.Equals(value))
                    return current;
            }

            return null;
        }

        public override string ToString() {
            if(Head == null)
                return "";

            var result = new StringBuilder(Head.Value.ToString());

            for(var current = Head.Next; current != null; current = current.Next) {
                result.Append("->" + current.Value.ToString());
            }
            
            return result.ToString();
        }
    }
}

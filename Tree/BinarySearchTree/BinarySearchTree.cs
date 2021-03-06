﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree {

    public class BinarySearchTree<T> where T: IComparable {

        public class Node {

            public Node Right { get; set; }
            public Node Left { get; set; }
            public T Value { get; set; }

            public Node(T value) {
                Value = value;
            }

        }

        public Node Root { get; set; }

        public void Add(T value) {
            Root = Add(Root, new Node(value));
        }

        private Node Add(Node parent, Node node) {
            if(parent == null)
                return node;

            switch(node.Value.CompareTo(parent.Value)) {
                case -1:
                    parent.Left = Add(parent.Left, node);
                    break;
                case 1:
                    parent.Right = Add(parent.Right, node);
                    break;
                default:
                    throw new Exception("Binary search tree should not contain duplicates!");
            }

            return parent;
        }

        public bool Contains(T value) {
            return Contains(Root, value);
        }

        private bool Contains(Node node, T value) {
            if(node == null)
                return false;

            switch(value.CompareTo(node.Value)) {
                case -1:
                    return Contains(node.Left, value);
                case 1:
                    return Contains(node.Right, value);
                default:
                    return true;
            }
        }

        public void Remove(T value) {
            Remove(Root, value, null);
        }

        private void Remove(Node node, T value, Node parent) {
            if(node == null)
                return;

            switch(value.CompareTo(node.Value)) {
                case 1:
                    Remove(node.Right, value, node);
                    break;
                case -1:
                    Remove(node.Left, value, node);
                    break;
                default:
                    DoRemove(node, value, parent);
                    break;
            }
        }

        private void DoRemove(Node node, T value, Node parent) {
            if(node.Left == null && node.Right == null) {
                SetParentChild(parent, node, null);
            } else if(node.Left == null) {
                SetParentChild(parent, node, node.Right);
            } else if(node.Right == null) {
                SetParentChild(parent, node, node.Left);
            } else {
                ReplaceNodeWithRightMostChildInLeftSubtree(node);
            }
        }

        private void ReplaceNodeWithRightMostChildInLeftSubtree(Node node) {
            var parent = node;
            var current = node.Left;
            
            while(current.Right != null) {
                parent = current;
                current = current.Right;
            }

            node.Value = current.Value;
            SetParentChild(parent, current, current.Left);
        }

        private void SetParentChild(Node parent, Node oldNode, Node newNode) {
            if(parent == null) {
                Root = newNode;
                return;
            }

            if(parent.Left == oldNode) {
                parent.Left = newNode;
            } else {
                parent.Right = newNode;
            }
        }

        public void InOrder(Action<T> handler) {
            InOrder(Root, handler);
        }

        private void InOrder(Node node, Action<T> handler) {
            if(node == null)
                return;

            InOrder(node.Left, handler);
            handler(node.Value);
            InOrder(node.Right, handler);
        }

        public void PreOrder(Action<T> handler) {
            PreOrder(Root, handler);
        }

        private void PreOrder(Node node, Action<T> handler) {
            if(node == null)
                return;

            handler(node.Value);
            PreOrder(node.Left, handler);
            PreOrder(node.Right, handler);
        }

        public void PostOrder(Action<T> handler) {
            PostOrder(Root, handler);
        }

        private void PostOrder(Node node, Action<T> handler) {
            if(node == null)
                return;

            PostOrder(node.Left, handler);
            PostOrder(node.Right, handler);
            handler(node.Value);
        }

        public void LevelOrder(Action<T> handler) {
            var queue = new Queue<Node>();
            queue.Enqueue(Root);

            while(queue.Count > 0) {
                var node = queue.Dequeue();
                
                if(node == null)
                    continue;

                handler(node.Value);

                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
        }

        public bool IsBalanced() {
            return IsBalanced(Root);
        }

        private bool IsBalanced(Node node) {
            if(node == null)
                return true; 

            return (Math.Abs(Height(node.Left) - Height(node.Right)) <= 1)
                && IsBalanced(node.Left)
                && IsBalanced(node.Right);
        }

        private int Height(Node node) {
            if(node == null)
                return 0;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public override string ToString() {
            return Stringify(Root);
        }

        private string Stringify(Node node) {
            if(node == null)
                return "";

            string leftSubtree = Stringify(node.Left);
            string rightSubtree = Stringify(node.Right);

            return String.Format("({0}{1}{2})", 
                String.IsNullOrEmpty(leftSubtree) ? "" : leftSubtree + " <- ",
                node.Value,
                String.IsNullOrEmpty(rightSubtree) ? "" : " -> " + rightSubtree);
        }

    }
}

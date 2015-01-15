using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;

namespace BinaryTreeLevelPrinting {

    /// <summary>
    /// Print binary tree levels as rows ending with newline sign 
    /// </summary>
    public class TreePrinter<T> where T: IComparable {

        private class NodeWithLevel {
            public BinarySearchTree<T>.Node Node { get; set; }
            public int Level { get; set; }

            public NodeWithLevel(BinarySearchTree<T>.Node node, int level = 0) {
                Node = node;
                Level = level;
            }
        }

        private readonly BinarySearchTree<T> _tree;

        public TreePrinter(BinarySearchTree<T> tree) {
            _tree = tree;
        }

        public string LevelPrint() {
            var result = new StringBuilder();
            var row = new StringBuilder();
            
            int level = 1;
            var queue = new Queue<NodeWithLevel>();
            queue.Enqueue(new NodeWithLevel(_tree.Root, level));

            while(queue.Count > 0) {
                var node = queue.Dequeue();
                
                if(node.Node == null)
                    continue;

                if(node.Level > level) {
                    result.AppendLine(row.ToString());
                    row = new StringBuilder();
                    level = node.Level;
                }

                row.Append((row.Length > 0 ? " " : "") + node.Node.Value.ToString());

                queue.Enqueue(new NodeWithLevel(node.Node.Left, level + 1));
                queue.Enqueue(new NodeWithLevel(node.Node.Right, level + 1));
            }

            result.Append(row.ToString());

            return result.ToString();
        }

        
    }
}

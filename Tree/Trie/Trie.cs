using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie {

    public class Trie {

        private const int ALPHABET_SIZE = 26;

        public class Node {

            public string Value { get; set; }
            public Node[] Children { get; set; }
            public bool IsLeaf { get; set; }
            public bool IsWord { get; set; }

            public Node(string value) {
                Value = value;
                Children = new Node[ALPHABET_SIZE];
                IsLeaf = true;
            }

        }

        private Node Root;

        public Trie() {
            Root = new Node("");
        }

        private int Index(char ch) {
            return ch - 'a';
        }

        public void AddWord(string word) {
            word = word.ToLower();
            var node = Root;

            for(int i = 0; i < word.Length; i++) {
                char ch = word[i];
                int index = Index(ch);
                var child = node.Children[index];

                if(child == null) {
                    child = new Node(ch.ToString());
                    node.Children[index] = child;
                    node.IsLeaf = false;
                }
                
                node = child;
            }

            node.IsWord = true;
        }

        public IList<string> FindWords(string prefix) {
            prefix = prefix.ToLower();
            var node = Root;

            for(int i = 0; i < prefix.Length; i++) {
                char ch = prefix[i];
                var child = node.Children[Index(ch)];

                if(child == null)
                    return new List<string>();

                node = child;
            }

            return GetWords(node, prefix.Substring(0, prefix.Length - 1));
        }

        private IList<string> GetWords(Node node, string prefix) {
            var result = new List<string>();
            GetWords(node, prefix, result);
            return result;
        } 

        private void GetWords(Node node, string word, IList<string> all) {
            word = word + node.Value;

            if(node.IsWord) {
                all.Add(word);
            }

            if(node.IsLeaf)
                return;

            foreach(Node child in node.Children) {
                if(child == null)
                    continue;

                GetWords(child, word, all);
            }
        }

        public override string ToString() {
            var result = GetWords(Root, "");
            return String.Join(", ", result.ToArray());
        }

    }

}

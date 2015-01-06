using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    /// <summary>
    /// Hash table implementation with separate chaining collision resolution
    /// </summary>
    public class HashMap<K, V> where K: IComparable {

        private class Item {
            public K Key { get; set; }
            public V Value { get; set; }
            public Item Next { get; set; }

            public Item(K key, V value) {
                Key = key;
                Value = value;
            }
        }

        private const int DEFAULT_CAPACITY = 256;

        private Item[] _items;

        private Item[] Items {
            get { return _items; }
        }

        public HashMap(int capacity = DEFAULT_CAPACITY) {
            _items = new Item[capacity];
        }

        public V Get(K key) {
            int index = GetIndex(key);
            Item item = FindItemInChain(Items[index], key);
            return item != null ? item.Value : default(V);
        }

        public void Put(K key, V value) {
            int index = GetIndex(key);

            if(Items[index] == null) {
                Items[index] = new Item(key, value);
                return;
            }
            
            Item item = FindItemInChain(Items[index], key);

            if(item == null) {
                AddItemToChain(Items[index], new Item(key, value));
            } else {
                item.Value = value;
            }
        }

        private int GetIndex(K key) {
            return key.GetHashCode() % Items.Length;
        }

        private Item FindItemInChain(Item head, K key) {
            Item current = head;

            while(current != null) {
                if(current.Key.Equals(key)) {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        private void AddItemToChain(Item head, Item item) {
            Item current = head;

            while(current.Next != null) {
                current = current.Next;
            }

            current.Next = item;
        }

        public void Remove(K key) {
            int index = GetIndex(key);
            Item item = Items[index];

            if(item == null)
                return;

            if(item.Key.Equals(key)) {
                Items[index] = item.Next;
                return;
            }

            RemoveFromChain(item, key);
        }

        private void RemoveFromChain(Item head, K key) {
            Item prev = head;
            Item current = prev.Next;

            while(current != null) {
                if(current.Key.Equals(key)) {
                    prev.Next = current.Next;
                    return;
                }
                prev = current;
                current = current.Next;
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();

            foreach(var item in Items) {
                var current = item;
                while(current != null) {
                    result.Append(String.Format("({0}: {1})", current.Key, current.Value));
                    current = current.Next;
                }
            }

            return result.ToString();
        }
    }
}

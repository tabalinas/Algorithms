using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting {

    public class BucketSorter: Sorter<int> {

        private readonly int _bucketCount;

        private int BucketCount {
            get { return _bucketCount; }
        }

        public BucketSorter(int[] array, int bucketCount): base(array) {
            _bucketCount = bucketCount;
        }

        public override void Sort() {
            List<int>[] buckets = PrepareBuckets();
            int min = Array.Min();
            int max = Array.Max();
            
            DistributeToBuckets(buckets, min, max);

            SortAndMerge(buckets);
        }

        private List<int>[] PrepareBuckets() {
            var buckets = new List<int>[BucketCount];
            for(int i = 0; i < BucketCount; i++) {
                buckets[i] = new List<int>();
            }
            return buckets;
        }

        private void DistributeToBuckets(List<int>[] buckets, int min, int max) {
            double bucketSize = (max - min + 1) / (double)BucketCount;

            foreach(int num in Array) {
                buckets[(int)((num - min) / bucketSize)].Add(num);
            }
        }

        private void SortAndMerge(List<int>[] buckets) {
            int index = 0;
            foreach(var bucket in buckets) {
                bucket.Sort();

                foreach(int num in bucket) {
                    Array[index++] = num;
                }
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingAverage
{
    public class ArrayUtils
    {
        public static double[] SlidingAverage(double[] source, int windowSize) {
            if(source == null || source.Length < windowSize)
                throw new ArgumentException();

            double[] result = new double[source.Length];

            double sum = 0;
            for(int i = 0; i < windowSize; i++) {
                sum += source[i];
            }

            var windowFitLastIndex = source.Length - windowSize;

            for(int i = 0; i < windowFitLastIndex; i++) {
                result[i] = sum / windowSize;
                sum += source[i + windowSize] - source[i];
            }

            for(int i = 0; i < windowSize; i++) {
                result[windowFitLastIndex + i] = sum / (windowSize - i);
                sum -= source[windowFitLastIndex + i];
            }

            return result;
        }
    }
}

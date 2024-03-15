using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInterview.Extensions
{
    internal static class ArrayExtensions
    {

        private static void Merge<T>(T[] values, int sortFrom, int middle, int sortTo)
            where T : IComparable<T>
        {
            int firstHalfLength = middle - sortFrom + 1;
            int secondHalfLength = sortTo - middle;

            T[] firstHalf = new T[firstHalfLength];
            T[] secondHalf = new T[secondHalfLength];
            int i, j;

            for (i = 0; i < firstHalfLength; ++i)
                firstHalf[i] = values[sortFrom + i];
            for (j = 0; j < secondHalfLength; ++j)
                secondHalf[j] = values[middle + 1 + j];

            i = 0;
            j = 0;

            int k = sortFrom;
            while (i < firstHalfLength && j < secondHalfLength)
            {
                if (firstHalf[i].CompareTo(secondHalf[j]) < 0)
                {
                    values[k] = firstHalf[i];
                    i++;
                }
                else
                {
                    values[k] = secondHalf[j];
                    j++;
                }
                k++;
            }

            while (i < firstHalfLength)
            {
                values[k] = firstHalf[i];
                i++;
                k++;
            }

            while (j < secondHalfLength)
            {
                values[k] = secondHalf[j];
                j++;
                k++;
            }
        }
        public static void MergeSort<T>(this T[] values, int sortFrom, int sortTo)
            where T : IComparable<T>
        {
            var t = typeof(int);
            if (values is not (sbyte[] 
                or byte[] 
                or short[] 
                or ushort[] 
                or int[] 
                or uint[] or 
                long[] or
                ulong[] or
                nint[] or
                nuint[]))
                throw new ArgumentException($"Tipo no valido para ordenamiento", nameof(values));


            if (sortFrom < sortTo)
            {
                int middle = sortFrom + (sortTo - sortFrom) / 2;

                values.MergeSort(sortFrom, middle);
                values.MergeSort(middle + 1, sortTo);

                Merge(values, sortFrom, middle, sortTo);
            }
        }
    }
}

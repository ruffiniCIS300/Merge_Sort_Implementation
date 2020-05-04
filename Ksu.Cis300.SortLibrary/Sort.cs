/* Sort.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.SortLibrary
{
    /// <summary>
    /// Contains several methods for sorting ILists of ints.
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Swaps the elements at the two given locations of the given list.
        /// </summary>
        /// <param name="list">The list containing the elements to swap.</param>
        /// <param name="i">The location of one of the elements.</param>
        /// <param name="j">The location of the other element.</param>
        private static void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the given IList using selection sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        public static void SelectionSort(IList<int> list)
        {
            int end = list.Count - 1;
            for (int i = 0; i < end; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                Swap(list, i, min);
            }
        }

        /// <summary>
        /// Sorts the given IList using insertion sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int j = i;
                int temp = list[j];
                while (j > 0 && temp < list[j - 1])
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = temp;
            }
        }
    }
}

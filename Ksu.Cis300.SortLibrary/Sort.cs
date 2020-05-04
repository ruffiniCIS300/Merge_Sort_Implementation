/* Sort.cs
 * Author: Nick Ruffini
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

        /// <summary>
        /// Merges two adjacent sorted portions of list into a single sorted portion!
        /// </summary>
        /// <param name="list"> Overall list that we are working with (entire thing) </param>
        /// <param name="start"> Starting index of the section to merge! </param>
        /// <param name="len1"> Size of the first section we are merging </param>
        /// <param name="len2"> Size of the second section we are merging </param>
        private static void Merge(IList<int> list, int start, int len1, int len2)
        {
            int[] temp = new int[len1 + len2];
            int pos1 = start;
            int pos2 = start + len1;
            int tempPos = 0;

            while ((pos1 < start + len1) && (pos2 < start + len1 + len2))
            {
                if (list[pos1] < list[pos2])
                {
                    temp[tempPos] = list[pos1];
                    pos1++;
                    tempPos++;
                }
                else
                {
                    temp[tempPos] = list[pos2];
                    pos2++;
                    tempPos++;
                }
            }
            while (pos1 < start + len1)
            {
                temp[tempPos] = list[pos1];
                pos1++;
                tempPos++;
            }
            while (pos2 < start + len1 + len2)
            {
                temp[tempPos] = list[pos2];
                pos2++;
                tempPos++;
            }

            int position = start;
            for (int i = 0; i < temp.Length; i++)
            {
                list[position] = temp[i];
                position++;
            }
        }

        /// <summary>
        /// Sorts a portion of a list using Merge Sort!
        /// </summary>
        /// <param name="list"> List that we are applying Merge Sort to </param>
        /// <param name="start"> The first position of the section we are sorting </param>
        /// <param name="len"> Number of elements starting from start that we are soriting </param>
        private static void MergeSort(IList<int> list, int start, int len)
        {
            if (len >= 2)
            {
                /*List<int> firstHalf = new List<int>();
                for (int i = start; i < len / 2; i++)
                {
                    firstHalf.Add(list[i]);
                }

                List<int> secondHalf = new List<int>();
                for (int j = start + len / 2; j < len; j++)
                {
                    secondHalf.Add(list[j]);
                }*/

                MergeSort(list, start, len / 2);
                MergeSort(list, start + len / 2, len - len / 2);

                Merge(list, start, len/2, len - len / 2);
            }
        }

        /// <summary>
        /// Calls MergeSort on the entire list
        /// </summary>
        /// <param name="list"> List that we are merge sorting! </param>
        public static void MergeSort(IList<int> list)
        {
            MergeSort(list, 0, list.Count);
        }
    }
}

/* SortTests.cs
 * Author: Rod Howell
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ksu.Cis300.SortLibrary.Tests
{
    /// <summary>
    /// Unit tests for the Sort class.
    /// </summary>
    [TestFixture]
    public class SortTests
    {
        /// <summary>
        /// Tests SelectionSort on a 10-element array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestASelectionSortSmall()
        {
            int[] data = new int[] { 3, -7, 0, 11, -7, 8, 4, 8, -2, 6 };
            int[] result = new int[data.Length];
            data.CopyTo(result, 0);
            Sort.SelectionSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Iniitializes two lists to the same sequence of random ints.
        /// </summary>
        /// <param name="data">The first list.</param>
        /// <param name="result">The second list.</param>
        /// <param name="n">The number of elements in each list, and the upper bound
        /// on their values (values will be nonnegative and less than n).</param>
        private void Initialize(IList<int> data, IList<int> result, int n)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                data.Add(r.Next(n));
                result.Add(data[i]);
            }
        }

        /// <summary>
        /// Tests SelectionSort on a random list of 100 elements.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBSelectionSort100()
        {
            List<int> data = new List<int>();
            List<int> result = new List<int>();
            Initialize(data, result, 100);
            Sort.SelectionSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        [Test, Timeout(20000)]
        /// <summary>
        /// Tests SelectionSort on a random list of 30000 elements.
        /// </summary>
        public void TestCSelectionSort30000()
        {
            List<int> data = new List<int>();
            List<int> result = new List<int>();
            Initialize(data, result, 30000);
            Sort.SelectionSort(result);
            Assert.That(result, Is.Ordered);
        }

        /// <summary>
        /// Tests InsertionSort on a 10-element array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDInsertionSortSmall()
        {
            int[] data = new int[] { 3, -7, 0, 11, -7, 8, 4, 8, -2, 6 };
            int[] result = new int[data.Length];
            data.CopyTo(result, 0);
            Sort.InsertionSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Tests InsertionSort on a random list of 100 elements.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEInsertionSort100()
        {
            List<int> data = new List<int>();
            List<int> result = new List<int>();
            Initialize(data, result, 100);
            Sort.InsertionSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        [Test, Timeout(20000)]
        /// <summary>
        /// Tests InsertionSort on a random list of 30000 elements.
        /// </summary>
        public void TestFInsertionSort30000()
        {
            List<int> data = new List<int>();
            List<int> result = new List<int>();
            Initialize(data, result, 30000);
            Sort.InsertionSort(result);
            Assert.That(result, Is.Ordered);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qa_tech_test.Utils;
using Xunit;

namespace qa_tech_test.Tests
{
    public class ArrayIndexUtilsTests
    {
        [Theory]
        [InlineData(new int[] {10, 15, 5, 7, 1, 24, 36, 2}, 5)]
        [InlineData(new int[] {23, 50, 63, 90, 10, 30, 155, 23, 18}, 4)]
        [InlineData(new int[] {133, 60, 23, 92, 6, 7, 168, 16, 19}, 3)]
        [InlineData(new int[] {30, 43, 29, 10, 50, 40, 99, 51, 12}, 5)]
        [InlineData(new int[] {10, 20, 30, 40, 50, 60}, null)]
        [InlineData(new int[] { 100, 20, 30, 40, 20, 10 }, 1)]
        [InlineData(new int[] { 10, 20, 30, 40, 20, 100 }, 4)]
        [InlineData(new int[] { 10, 20, 30, 40, 20, 120 }, null)]
        [InlineData(new int[] { 100 }, null)]
        [InlineData(new int[] { 100,100 }, null)]
        [InlineData(new int[] { 100,1,100 },1)]

        public void ShouldReturnCorrectBalanceIndexForArray(int[] array, int? expectedIndex)
        {
            Assert.Equal(expectedIndex, ArrayIndexUtils.GetIndexWhereArrayIsBalanced(array));
        }

    }
}
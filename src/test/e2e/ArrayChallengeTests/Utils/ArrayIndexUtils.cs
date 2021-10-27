using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace qa_tech_test.Utils
{
    class ArrayIndexUtils
    {
        public static int? GetIndexWhereArrayIsBalanced(int[] items)
        {
            int? indexResult=null;
            int leftSubArraySum = 0;
            int rightSubArraySum = 0;

            for (int indexToTest = 0; indexToTest <items.Length-1; indexToTest++)
            {
                leftSubArraySum = 0;
                rightSubArraySum = 0;
                // Add element to the left of current index
                for (int leftArrIndex = 0; leftArrIndex < indexToTest; leftArrIndex++)
                {
                    leftSubArraySum += items[leftArrIndex];
                }

                // Add element to the right of current index
                for (int rightArrIndex =indexToTest+1 ; rightArrIndex < items.Length; rightArrIndex++)
                {
                    rightSubArraySum += items[rightArrIndex];
                }

                if (leftSubArraySum == rightSubArraySum)
                {
                    indexResult = indexToTest;
                    break;
                }
            }

            return indexResult;
        }
    }
}

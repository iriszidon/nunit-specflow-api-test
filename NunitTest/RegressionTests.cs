using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTest
{
    public class RegressionTests
    {
        //Get array of int
        // return the 2nd largest number
        // Use primitives only, no max min 
        // one trasition on the list ONLY

        public int FindSecondLargestNumber(List<int> input)
        {
            int result = 0;
            int firstIndex = input.First();
            int secondIndex = input.ElementAt(1);
            int max;
            int secondMax;
            // Init first two
            if (firstIndex < secondIndex)
            {
                max = secondIndex;
                secondMax = firstIndex;
            }
            else
            {
                secondMax = secondIndex;
                max = firstIndex;
            }
            for (int i = 2; i < input.Count; i++)
            {
                //case: max = 10, secondMax = 2, input = 8
                if (input.ElementAt(i) < max && input.ElementAt(i) > secondMax)
                {
                    secondMax = input.ElementAt(i);
                }
                //case: max = 10, secondMax = 2, input = 13
                else if(input.ElementAt(i) > max)
                {
                    secondMax = max;
                    max = input.ElementAt(i);
                }
            }
            return secondMax;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    //This will store int array[10000]
    //Will assign this array with random numbers in the constructor
    //Has DistinctIntegerOne~Three will get the distinct intergers from the array[10000]
    public class DistinctIntegers
    {
        int[] array = new int[10000];
        //initialize a int list with 10000 elements
        
        //Generate random numbers in the constructor
        public DistinctIntegers()
        {
            Random rand = new Random();
            //create 10000 rundom numbers
            for (int i = 0; i < 10000; i++)
            {
                array[i] = rand.Next(0, 20000);

            }
            
        }
        //get the distinct intergers from the array[10000], using hash
        public int DistinctIntegersOne()
        {
            //Hash will not contain duplicates
            HashSet<int> myhash = new HashSet<int>();
            int i;
            for (i = 0; i < array.Length; i++)
            {
                myhash.Add(array[i]);

            }

            return myhash.Count;
        }
        //get the distinct intergers from the array[10000], in O(1) space
        public int DistinctIntegersTwo()
        {
            //return number of disctinct integers in O(1) space
            //subtract when find duplicate
            int mynum = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        mynum--;
                        break;

                    }

                }

            }
            return mynum;
        }
        //get the distinct intergers from the array[10000], using sort
        public int DistinctIntegersThree()
        {
            //sort list
            Array.Sort(array);
            int mynum = array.Length;
            //subtract when find duplicate
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    mynum--;
                }
            }
            return mynum;

        }
    }
}

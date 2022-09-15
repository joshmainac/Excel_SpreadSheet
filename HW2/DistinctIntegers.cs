using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class DistinctIntegers
    {
        int[] array = new int[10000];
        //initialize a int list with 10000 elements
        

        public DistinctIntegers()
        {
            Random rand = new Random();
            //create 10000 rundom numbers
            for (int i = 0; i < 10000; i++)
            {
                array[i] = rand.Next(0, 20000);

            }
            
        }

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

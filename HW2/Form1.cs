using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RunDistinctIntegers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int DistinctIntegersOne(int[] array)
        {
            //int[] distinctArray = array.Distinct().ToArray();
            //lblHelloWorld.Text = Convert.ToString(distinctArray.Count());
            //lblHelloWorld2.Text = Convert.ToString(distinctArray.Count());
            HashSet<int> myhash = new HashSet<int>();
            int i;
            for (i = 0; i < array.Length; i++)
            {
                myhash.Add(array[i]);

            }

            return myhash.Count;
        }

        private int DistinctIntegersTwo(int[] array)
        {
            //return number of disctinct integers in O(1) space
            int mynum = array.Length;
            int dd = 0;
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

        private int DistinctIntegersThree(int[] array)
        {
            //sort list
            Array.Sort(array);
            int mynum = array.Length;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    mynum--;
                }
            }
            return mynum;

        }

        private void RunDistinctIntegers() // this is your method
        {
            int[] numbers = new int[10000];

            int i = 0;
            //HashSet<int> myhash = new HashSet<int>();
            //random number generator
            Random rand = new Random();
            //create 10000 rundom numbers
            for (i = 0; i < 10000; i++)
            {
                numbers[i] = rand.Next(0, 20000);

            }


            int resOne = DistinctIntegersOne(numbers);
            int resTwo = DistinctIntegersTwo(numbers);
            int resThree = DistinctIntegersThree(numbers);





            lblHelloWorld3.Text = "1. Hash Set method: " + resOne + " unique numbers" + Environment.NewLine +
                "Here you will have info about the time complexity of your code" + Environment.NewLine +
                "You also need info about how you determined it" + Environment.NewLine +
                "2. O(1) storage method: " + resTwo + " unique numbers" + Environment.NewLine +
                "3. Sorted method: " + resThree + " unique numbers";










        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

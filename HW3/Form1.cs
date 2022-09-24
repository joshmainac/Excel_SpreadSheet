using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
namespace HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //. It should read all the text from the TextReader object and put it in the text box in your interface.
        private void LoadText(TextReader sr)
        {
            string readfile = sr.ReadToEnd();
            textBox1.Text = readfile;

        }

        //This button Load a file
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(filename);
            LoadText(sr);

        }

        //This button will save a file
        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    //write to file
                    StreamWriter sw = new StreamWriter(myStream);
                    sw.Write(textBox1.Text);
                    sw.Close();
                    myStream.Close();
                }
            }

        }

        //call FibonacciTextReader and generate the first 50 Fibonacci sequence
        private void FibonacciFifty()
        {
            FibonacciTextReader obj1 = new FibonacciTextReader(50);
            textBox1.Text = obj1.ReadToEnd();
        }

        //Fibonacci 50 button will call FibonacciFifty()
        private void button3_Click(object sender, EventArgs e)
        {
            FibonacciFifty();

        }

         //call FibonacciTextReader and generate the first 100 Fibonacci sequence
        private void FibonacciHundred()
        {
            FibonacciTextReader obj1 = new FibonacciTextReader(100);
            textBox1.Text = obj1.ReadToEnd();
        }

        //Fibonacci 100 button will call FibonacciFifty()
        private void button4_Click(object sender, EventArgs e)
        {
            FibonacciHundred();
        }
    }
}

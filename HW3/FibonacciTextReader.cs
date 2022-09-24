using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HW3
{
    /// This class can return the next Fibonacci number in the sequence
    class FibonacciTextReader : System.IO.TextReader
    {
        private int maxLines;
        private int currentLine;
        private BigInteger currentNumber;
        private BigInteger previousNumber;


        //b. make a constructor that takes an integer as a parameter indicating the maximum number of lines available (the maximum number of numbers in the sequence that you can generate).
        public FibonacciTextReader(int maxLines)
        {
            this.maxLines = maxLines;
            currentLine = 0;
            currentNumber = 0;
            previousNumber = 0;
        }

        //c. override the ReadLine method to return the next number in the sequence. 
        //The first line should return 0, the second line should return 1, the third line should return 1, the fourth line should return 2, and so on.
        public override string ReadLine()
        {
            if (currentLine == 0)
            {
                currentLine++;
                return "0";
            }
            else if (currentLine == 1)
            {
                currentLine++;
                currentNumber = 1;
                return "1";
            }
            else if (currentLine < maxLines)
            {
                currentLine++;
                BigInteger temp = currentNumber;
                currentNumber = currentNumber + previousNumber;
                previousNumber = temp;
                return currentNumber.ToString();
            }
            else
            {
                return null;
            }
        }

        //override the ReadToEnd so it t repeatedly calls ReadLine and concatenates all the linestogether.
        //use e System.Text.StringBuilder class to append the lines togetherinto one string.
        public override string ReadToEnd()
        {
            int curr = 1;
            StringBuilder sb = new StringBuilder();
            string line = ReadLine();
            while (line != null)
            {
                sb.Append(curr + ": ");
                curr += 1;
                sb.Append(line);
                sb.Append(Environment.NewLine);
                line = ReadLine();
            }
            return sb.ToString();
        }

    }
}

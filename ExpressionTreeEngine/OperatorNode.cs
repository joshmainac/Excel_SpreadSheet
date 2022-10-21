using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    internal class OperatorNode : Node
    {
        public OperatorNode(char c)
        {
            Operator = c;
            Left = Right = null;
        }

        public char Operator { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}

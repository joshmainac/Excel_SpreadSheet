using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    internal class AddNode : OperatorNode
    {
        public AddNode()
        {
            this.Operator = '+';
        }

        public override ushort Precedence { get; set; } = 1;



        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}

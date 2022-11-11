using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    internal class SubNode : OperatorNode
    {
        public SubNode()
        {
            this.Operator = '-';
        }

        public override ushort Precedence { get; set; } = 1;


        public override double Evaluate()
        {
            return this.Left.Evaluate() - this.Right.Evaluate();
        }
    }
}

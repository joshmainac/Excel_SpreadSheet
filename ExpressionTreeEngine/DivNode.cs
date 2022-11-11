using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    internal class DivNode : OperatorNode
    {
        public DivNode()
        {
            this.Operator = '/';
        }

        public override ushort Precedence { get; set; } = 2;



        public override double Evaluate()
        {
            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}

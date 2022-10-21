using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    internal class ConstantNode : Node
    {
        public double Value { get; set; }
    }
}

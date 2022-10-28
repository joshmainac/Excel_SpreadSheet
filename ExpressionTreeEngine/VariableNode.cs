using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    internal class VariableNode : Node
    {
        public string Name { get; set; }
        public VariableNode(string name)
        {
            Name = name;

        }

        public override double Evaluate()
        {
            //return ExpressionTree.variables[Name];
            if (ExpressionTree.variables.ContainsKey(Name))
            {
                return ExpressionTree.variables[Name];
            }
            else
            {
                return 0;
            }



        }

    }


}

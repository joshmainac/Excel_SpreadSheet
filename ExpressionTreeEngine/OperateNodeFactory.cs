using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    class OperateNodeFactory
    {
        public static OperatorNode CreateOperatorNode(char op)
        {

            Dictionary<char, OperatorNode> OperatorDict = new Dictionary<char, OperatorNode>()
            {
                {'+', new AddNode()},
                {'-', new SubNode()},
                {'*', new MulNode()},
                {'/', new DivNode()}

            };
            if (OperatorDict.ContainsKey(op))
            {
                return OperatorDict[op];
            }
            else
            {
                throw new ArgumentException("Invalid operator");
                //return null;
            }


        }
    }
}

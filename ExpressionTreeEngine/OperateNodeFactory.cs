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
            //switch (op)
            //{
            //    case '+':
            //        return new AddNode();
            //    case '-':
            //        return new SubNode();
            //    case '*':
            //        return new MulNode();
            //    case '/':
            //        return new DivNode();
            //    default:
            //        throw new ArgumentException("Invalid operator");

            //}
            switch (op)
            {
                case '+':
                    return new OperatorNode(op);
                case '-':
                    return new OperatorNode(op);
                case '*':
                    return new OperatorNode(op);
                case '/':
                    return new OperatorNode(op);
                default:
                    throw new ArgumentException("Invalid operator");

            }
          


        }
    }
}

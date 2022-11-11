using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    class OperateNodeFactory
    {
        private static Dictionary<char, Type> operators = new Dictionary<char, Type>();
        private delegate void OnOperator(char op,Type type);

        public OperateNodeFactory()
        {
            TraverseAvailableOperators((op, type) => operators.Add(op, type));
            
        }

        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            //get the type decleration OperatorNode
            Type operatorNodeType = typeof(OperatorNode);
            //Iterate over all loaded assemblies
            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                //get all types that inherit from our operatorNode class using LINQ
                //access the assembly and get all types that are assignable from operatorNode
                IEnumerable<Type> operatorTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));
                foreach (var type in operatorTypes)
                {
                    // for each subclass, retrieve the Operator property
                    PropertyInfo operatorField = type.GetProperty("Operator");
                    if (operatorField != null)
                    {
                        // Get the character of the Operator
                        object value = operatorField.GetValue(type);
                        if (value is char)
                        {
                            char operatorSymbol = (char)value;
                            onOperator(operatorSymbol, type);

                        }

                    }

                }
            }

        }
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

        public static OperatorNode CreateOperatorNode2(char op)
        {
            if (operators.ContainsKey(op))
            {
                object operatorNodeObject = System.Activator.CreateInstance(operators[op]);
                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }
            }
            throw new Exception("Unhandled operator");
        }
    }
}

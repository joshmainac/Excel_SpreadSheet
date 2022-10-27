﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeEngine
{
    public class ExpressionTree
    {
        private Node root;
        internal static Dictionary<string, double> variables = new Dictionary<string, double>();
        public string PostFixExpression { get; set; }
        public ExpressionTree(string expression)
        {
            CreatePostfix(expression);
            root = Compile(expression);
        }

        private OperatorNode Root { get; set; }
        private static Node Compile(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            // Check for extra parentheses and get rid of them, e.g. (((((2+3)-(4+5)))))
            if ('(' == s[0])
            {
                int parenthesisCounter = 1;
                for (int characterIndex = 1; characterIndex < s.Length; characterIndex++)
                {
                    // if open parenthisis increment a counter
                    if ('(' == s[characterIndex])
                    {
                        parenthesisCounter++;
                    }
                    // if closed parenthisis decrement the counter
                    else if (')' == s[characterIndex])
                    {
                        parenthesisCounter--;
                        // if the counter is 0 check where we are
                        if (0 == parenthesisCounter)
                        {
                            if (characterIndex != s.Length - 1)
                            {
                                // if we are not at the end, then get out (there are no extra parentheses)
                                break;
                            }
                            else
                            {
                                // Else get rid of the outer most parentheses and start over
                                return Compile(s.Substring(1, s.Length - 2));
                            }
                        }
                    }
                }
            }

            // define the operators we want to look for in that order
            char[] operators = { '+', '-', '*', '/', '^' };
            foreach (char op in operators)
            {
                Node n = Compile(s, op);
                if (n != null) return n;
            }

            // what can we see here?  
            double number;
            // a constant
            if (double.TryParse(s, out number))
            {
                // We need a ConstantNode
                //mod
                return new ConstantNode(number);
            }
            // or variable
            else
            {

                return new VariableNode(s);
            }
        }
       
        private static Node Compile(string expression, char op)
        {
            // track the parentheses
            int parenthesisCounter = 0;
            // iterate from back to front
            for (int expressionIndex = expression.Length - 1; expressionIndex >= 0; expressionIndex--)
            {
                // if closed parenthisis INcrement the counter
                if (')' == expression[expressionIndex])
                {
                    parenthesisCounter++;
                }
                // if open parenthisis DEcrement the counter
                else if ('(' == expression[expressionIndex])
                {
                    parenthesisCounter--;
                }
                // if the counter is at 0 and we have the operator that we are looking for
                if (0 == parenthesisCounter && op == expression[expressionIndex])
                {
                    // build an operator node
                    //OperatorNode operatorNode = new OperatorNode(expression[expressionIndex]);
                    OperatorNode operatorNode = OperateNodeFactory.CreateOperatorNode(expression[expressionIndex]);


                    // and start over with the left and right sub-expressions
                    operatorNode.Left = Compile(expression.Substring(0, expressionIndex));
                    operatorNode.Right = Compile(expression.Substring(expressionIndex + 1));
                    return operatorNode;
                }
            }

            // if the counter is not at 0 something was off
            if (parenthesisCounter != 0)
            {
                // throw a general exception
                throw new Exception();
            }
            // we did not find the operator
            return null;
        }
        
        public void SetVariable(string name, double value)
        {
            variables[name] = value;
        }

        public double Evaluate()
        {
            //return Evaluate(root);
            return root.Evaluate();
        }

        //Parse the expression string and build the expression tree more elegantly
        //use The Shunting Yard Algorithm
        //Transform the expression into a postfix order
        private void CreatePostfix(string s)
        {
            //use Shunting Yard Algorithm
            Queue<string> postfixQueue = new Queue<string>();
            Stack<char> operatorStack = new Stack<char>();
            Stack<Node> operandStack = new Stack<Node>();
            //the givem expression is in infix order we want to convert this to postfix
            //iterate through the expression
            for (int i = 0; i < s.Length; i++)
            {
                //if the character is a digit
                if (char.IsDigit(s[i]))
                {
                    //add the digit to the postfix queue
                    //handle more then one diget numbers with a loop
                    string number = string.Empty;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        number += s[i];
                        i++;
                    }
                    i--;
                    postfixQueue.Enqueue(number);

                }
                //if the character is an operator
                else if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/' || s[i] == '^')
                {
                    //if the operator stack is empty
                    if (operatorStack.Count == 0)
                    {
                        //push the operator to the operator stack
                        operatorStack.Push(s[i]);
                    }
                    //if the operator stack is not empty
                    else
                    {
                        //if the precedence of the operator on the top of the operator stack is greater than or equal to the precedence of the current operator
                        if (GetPrecedence(operatorStack.Peek()) >= GetPrecedence(s[i]))
                        {
                            //pop the operator from the operator stack and add it to the postfix queue
                            postfixQueue.Enqueue(operatorStack.Pop().ToString());
                            //push the current operator to the operator stack
                            operatorStack.Push(s[i]);
                        }
                        //if the precedence of the operator on the top of the operator stack is less than the precedence of the current operator
                        else
                        {
                            //push the current operator to the operator stack
                            operatorStack.Push(s[i]);
                        }
                    }
                }
                //if the character is an open parenthesis
                else if (s[i] == '(')
                {
                    //push the open parenthesis to the operator stack
                    operatorStack.Push(s[i]);
                }
                //if the character is a closed parenthesis
                else if (s[i] == ')')
                {
                    //while the operator on the top of the operator stack is not an open parenthesis
                    while (operatorStack.Peek() != '(')
                    {
                        //pop the operator from the operator stack and add it to the postfix queue
                        postfixQueue.Enqueue(operatorStack.Pop().ToString());
                    }
                    //pop the open parenthesis from the operator stack
                    operatorStack.Pop();
                }
                else if (s[i] == ' ')
                {

                }
                else
                {
                    //this handles variables
                    //update index till end of variable
                    string variableNameBuilder = "";
                    int temp = i;

                    while (i < s.Length && char.IsLetter(s[i]))
                    {
                        variableNameBuilder += s[i];
                        i++;
                    }
                    //add the variable to the postfix queue
                    postfixQueue.Enqueue(variableNameBuilder);
                    i--;





                }
            }
            //update PostFixExpression 
            PostFixExpression = string.Join(" ", postfixQueue.ToArray());
            //update the postfix queue
            while (operatorStack.Count != 0)
            {
                postfixQueue.Enqueue(operatorStack.Pop().ToString());
            }
            PostFixExpression = string.Join(" ", postfixQueue.ToArray());


        }
        //(2+3)*(4+5)
        //23+45+* 

        //x ^ y / (5 * z) + 10
        //x y ^ 5 z * / 10 +


        private static int GetPrecedence(char op)
        {
            //if the operator is a plus or minus
            if (op == '+' || op == '-')
            {
                //return 1
                return 1;
            }
            //if the operator is a multiply or divide
            else if (op == '*' || op == '/')
            {
                //return 2
                return 2;
            }
            //if the operator is a power
            else if (op == '^')
            {
                //return 3
                return 3;
            }
            //if the operator is not a plus, minus, multiply, divide, or power
            else
            {
                //return 0
                return 0;
            }
        }





    }
}

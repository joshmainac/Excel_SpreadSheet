using System;
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
            ClearVariables();
            CreatePostfix(expression);
            //root = Compile(expression);
            BuildTree();
        }

        private OperatorNode Root { get; set; }       
        
        public void SetVariable(string name, double value)
        {
            variables[name] = value;
        }

        public string [] GetVariableNames()
        {
            List<string> variableNames = new List<string>();
            string[] tokens = PostFixExpression.Split(' ');
            foreach(var token in tokens)
            {
                //if token does not include A-Z skip it
                if (token.Any(char.IsLetter))
                {
                    variableNames.Add(token);
                }
            }
            return variableNames.ToArray();


        }

        public void ClearVariables()
        {
            variables.Clear();
        }

        public double Evaluate()
        {
            //return Evaluate(root);
            return root.Evaluate();
        }

        //new compile
        //Parse the expression string and build the expression tree more elegantly
        //use The Shunting Yard Algorithm
        //Transform the expression into a postfix order
        private void CreatePostfix(string s)
        {
            OperateNodeFactory factory = new OperateNodeFactory();
            //use Shunting Yard Algorithm
            Queue<string> postfixQueue = new Queue<string>();
            Stack<char> operatorStack = new Stack<char>();
            Stack<Node> operandStack = new Stack<Node>();
            //the givem expression is in infix order we want to convert this to postfix
            //iterate through the expression
            for (int i = 0; i < s.Length; i++)
            {
                
                
                //if the character is an open parenthesis
                if (s[i] == '(')
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
                //if the character is a digit
                else if (char.IsDigit(s[i]))
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
                else if (!char.IsLetter(s[i]))
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


                        //create operatprNodefactory class
                        
                        //create a new operator node
                        //ushort presidence2  = factory.CreateOperatorNode(s[i]).Precedence;


                        ushort presidence1;
                        //ushort presidence2 = OperateNodeFactory.CreateOperatorNode(s[i]).Precedence;
                        ushort presidence2 = factory.CreateOperatorNode(s[i]).Precedence;

                        if (operatorStack.Peek() == '(' || operatorStack.Peek() == ')')
                        {
                            presidence1 = 0;
                        }
                        else
                        {
                            //presidence1 = OperateNodeFactory.CreateOperatorNode(operatorStack.Peek()).Precedence;
                            presidence1 = factory.CreateOperatorNode(operatorStack.Peek()).Precedence;
                        }

                        if (presidence1 >= presidence2)
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
                else
                {
                    //this handles variables
                    //update index till end of variable
                    string variableNameBuilder = "";
       
                    //make this handle variables and numbers like A1 B2.
                    while (i < s.Length && (char.IsLetter(s[i]) || char.IsDigit(s[i])))
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



        //Builed the expression tree from the PostFixExpression 
        private void BuildTree()
        {
            OperateNodeFactory factory = new OperateNodeFactory();
            //tokenize the PostFixExpression
            string[] tokens = PostFixExpression.Split(' ');
            //create a stack
            Stack<Node> stack = new Stack<Node>();
            //iterate through the tokens
            for (int i = 0; i < tokens.Length; i++)
            {
                //if the token is a number
                if (tokens[i].All(char.IsDigit))
                {
                    //create a number node
                    ConstantNode numberNode = new ConstantNode(double.Parse(tokens[i]));
                    //push the number node to the stack
                    stack.Push(numberNode);
                }
                //if the token is a variable. variable can include degits
                else if (tokens[i].Any(char.IsLetter))
                {
                    //create a variable node
                    VariableNode variableNode = new VariableNode(tokens[i]);
                    //push the variable node to the stack
                    stack.Push(variableNode);
                }
                //if the token is an operator
                else
                {
                    //create an operator node
                    //OperatorNode operatorNode = OperateNodeFactory.CreateOperatorNode(tokens[i][0]);
                    //OperatorNode operatorNode = OperatorNodeFactory.CreateOperatorNode2(tokens[i][0]);
                    OperatorNode operatorNode = factory.CreateOperatorNode(tokens[i][0]);

                    //pop the right node from the stack
                    Node rightNode = stack.Pop();
                    //pop the left node from the stack
                    Node leftNode = stack.Pop();
                    //set the left node of the operator node to the left node
                    operatorNode.Left = leftNode;
                    //set the right node of the operator node to the right node
                    operatorNode.Right = rightNode;
                    //push the operator node to the stack
                    stack.Push(operatorNode);
                }
            }

            //set the root node to the node on the top of the stack
            root = (OperatorNode)stack.Pop();


        }

      






    }
}

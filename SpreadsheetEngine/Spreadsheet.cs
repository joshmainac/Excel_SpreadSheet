using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    class Spreadsheet 
    {
        //add a 2D array of Cell objects
        protected Cell[,] Cells;
        //make a constructor that takes in the number of rows and columns
        public Spreadsheet(int rows, int columns)
        {
            //create a 2D array of cells
            this.Cells = new Cell[rows, columns];
            //loop through the rows
            for (int r = 0; r < rows; r++)
            {
                //loop through the columns
                for (int c = 0; c < columns; c++)
                {
                    //create a new cell from abstruct class Cell
                    Cells[r, c] = new TextCell();
                    //Cells[r, c].ColumnIndex = c;
                    //Cells[r, c].RowIndex = r;
                    Cells[r, c].Text = "";

                    //Cells[r, c].PropertyChanged += CellPropertyChanged;


                }
            }

            //make CellPropertyChanged
            private void CellPropertyChanged(object sender,EventArgs e)
            {
                //get the cell that fired the event
                Cell cell = sender as Cell;
                //if the cell is null, return
                if (cell == null)
                    return;
                //if the property that changed is Text
                if (e.ToString() == "Text")
                {
                    //get the value of the cell
                    cell.Value = EvaluateCell(cell);
                }
            }

            private void EvaluateCell(Cell cell)
            {
                //get the text of the cell
                string text = cell.Text;
                //if the text is empty, return empty string
                if (text == "")
                    return "";
                //if the text starts with an equal sign
                if (text[0] == '=')
                {
                    //get the expression
                    string expression = text.Substring(1);
                    //split the expression into tokens
                    string[] tokens = expression.Split(' ');
                    //if there are 3 tokens
                    if (tokens.Length == 3)
                    {
                        //get the first token
                        string token1 = tokens[0];
                        //get the second token
                        string token2 = tokens[1];
                        //get the third token
                        string token3 = tokens[2];
                        //if the second token is an operator
                        if (token2 == "+" || token2 == "-" || token2 == "*" || token2 == "/")
                        {
                            //get the value of the first token
                            double value1 = GetValue(token1);
                            //get the value of the third token
                            double value2 = GetValue(token3);
                            //if the value of the first token is not null
                            if (value1 != null)
                            {
                                //if the value of the third token is not null
                                if (value2 != null)
                                {
                                    //if the second token is a plus
                                    if (token2 == "+")
                                    {
                                        //return the sum of the two values
                                        return (value1 + value2).ToString();
                                    }
                                    //if the second token is a minus
                                    if (token2 == "-")
                                    {
                                        //return the difference of the two values
                                        return (value1 - value2).ToString();
                                    }
                                    //if the second token is a times
                                    if (token2 == "*")
                                    {
                                        //return the product of the two values
                                        return (value1 * value2).ToString();
                                    }
                                    //if the second token is a divide
                                    if (token2 == "/")
                                    {
                                        //return the quotient of the two values
                                        return (value1 / value2).ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                //if the text is not an expression, return the text
                return text;
            }


        }
    }
}

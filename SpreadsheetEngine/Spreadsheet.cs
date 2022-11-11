using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using ExpressionTreeEngine;

namespace SpreadsheetEngine
{
    public class Spreadsheet : INotifyPropertyChanged
    {
     
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
                    Cells[r, c].ColumnIndex = c;
                    Cells[r, c].RowIndex = r;
                    Cells[r, c].Text = "";

                    //when cell OnpropertyChange it will run spreadsheet  CellPropertyChanged
                    Cells[r, c].PropertyChanged += CellPropertyChanged;
                    //this means when cell Text change, call spreadsheet CellPropertyChanged(object sender, EventArgs e)


                }
            }

        }

        
        //public event PropertyChangedEventHandler PropertyChanged;
        //add a 2D array of Cell objects
        private Cell[,] Cells;
    


        //Add properties ColumnCount and RowCount that return the number of columns and rows in the spreadsheet, respectively
        public int ColumnCount
        {
            get
            {
                return Cells.GetLength(1);
            }
        }
        public int RowCount
        {
            get
            {
                return Cells.GetLength(0);
            }
        }


        //+= From to this event
        public event PropertyChangedEventHandler PropertyChanged;
        //this is called by event and will also call a event
        private void CellPropertyChanged(object sender, EventArgs e)
        {
            
            Cell changedCell = (Cell)sender;
            string myValue = Evaluate(changedCell);
            changedCell.Value = myValue;
            PropertyChanged?.Invoke(changedCell, new PropertyChangedEventArgs("Cell"));

        }
        private string Evaluate(Cell cell)
        {
            //get the text of the cell
            string text = cell.Text;
            //if the text is empty, return empty string
            if (text == "")
                return "";
            //if the text starts with an equal sign
            if (text[0] == '=')
            {
                //remove the equal sign
                string expression = text.Substring(1) + "+0";
                ExpressionTree expressionTree = new ExpressionTree(expression);

                //use GetVariableNames to set variables
                string[] variables = expressionTree.GetVariableNames();
                foreach (string variable in variables)
                {
                    //get the row and column index of the variable
                    int column = variable[0] - 'A';
                    int row = int.Parse(variable.Substring(1)) - 1;
                    //get the value of the cell
                    string value = Cells[row, column].Value;
                    //if the value is empty, return empty string
                    if (value == "")
                        return "";
                    //set the variable in the expression tree
                    expressionTree.SetVariable(variable, double.Parse(value));
                    //add event handler to the cell for ref

                    //HW7 part3 cell reference
                    //Cells[row,column] is the variable cell, and cell is the cell that use that Cells[row,column] as a variable
                    //when Cell[row,column] change property, it will also trigger RefPropertychanged
                    Cells[row, column].PropertyChanged += cell.OnRefPropertyChanged;

                }



                return expressionTree.Evaluate().ToString();
                




            }
            else return cell.Text;



        }

        public Cell GetCell(int row, int column)
        {
            //mod this
            return Cells[row, column];
        }

        public Cell GetCell(string name)
        {
            //get the column index
            int columnIndex = name[0] - 'A';
            //get the row index
            int rowIndex = int.Parse(name.Substring(1)) - 1;
            //return the cell
            return Cells[rowIndex, columnIndex];
        }

        




    }
}









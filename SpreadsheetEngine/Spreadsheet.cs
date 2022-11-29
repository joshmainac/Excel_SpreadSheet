using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using System.Drawing;

using ExpressionTreeEngine;

using System.IO;
using System.Xml;



namespace SpreadsheetEngine
{
    public class Spreadsheet : INotifyPropertyChanged
    {
     
        public Spreadsheet(int rows, int columns)
        {

            
      

            //create a 2D array of cells
            this.Cells = new Cell[rows, columns];
            //initialize the undos
            this.Undos = new Stack<UndoRedoCollection>();
            this.Redos = new Stack<UndoRedoCollection>();

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
                    Cells[r, c].BGColor = 0xFFFFFFFF;

                    //when cell OnpropertyChange it will run spreadsheet  CellPropertyChanged
                    Cells[r, c].PropertyChanged += CellPropertyChanged;
                    //this means when cell Text change, call spreadsheet CellPropertyChanged(object sender, EventArgs e)


                }
            }

        }

        
        //public event PropertyChangedEventHandler PropertyChanged;
        //add a 2D array of Cell objects
        private Cell[,] Cells;

        //undo redo stack
         private Stack<UndoRedoCollection> Undos;
         private Stack<UndoRedoCollection> Redos;

    


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

            if (this.IsBadRef(cell))
            {
                return "!(bad reference)";

            }

            if (this.IsSelfRef(cell))
            {
                return "aaa";

            }

            if (this.IsCircularRef(cell))
            {
                return "aaa";

            }



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

        //undo redo frunctions
        public void AddUndo(Cell undoRedoCell,string propertyname)
        {
            //Cell mycell = new undoRedoCell
            //make new cell mycell and copy the value of undoRedoCell
            Cell mycell = new TextCell();
            mycell.ColumnIndex = undoRedoCell.ColumnIndex;
            mycell.RowIndex = undoRedoCell.RowIndex;
            mycell.Text = undoRedoCell.Text;
            mycell.BGColor = undoRedoCell.BGColor;



            UndoRedoCollection mycollection = new UndoRedoCollection(mycell);
            mycollection.PropertyName = propertyname;
            this.Undos.Push(mycollection);
        }





        public void AddRedo(Cell undoRedoCell, string propertyname)
        {
            //Cell mycell = new undoRedoCell
            //make new cell mycell and copy the value of undoRedoCell
            Cell mycell = new TextCell();
            mycell.ColumnIndex = undoRedoCell.ColumnIndex;
            mycell.RowIndex = undoRedoCell.RowIndex;
            mycell.Text = undoRedoCell.Text;
            mycell.BGColor = undoRedoCell.BGColor;


            UndoRedoCollection mycollection = new UndoRedoCollection(mycell);
            mycollection.PropertyName = propertyname;
            this.Redos.Push(mycollection);
        }


        public void ExecuteUndo()
        {
            if (Undos.Count > 0)
            {
                //pop one value from Undo(old cell)
                UndoRedoCollection undo = Undos.Pop();
                //save currentcell in Redo
                Cell CurrentCell = this.GetCell(undo.Oldcell.RowIndex, undo.Oldcell.ColumnIndex);
                AddRedo(CurrentCell,undo.PropertyName);
                //undo -> CurrentCell, update currentcell to undo(oldcell)
                undo.Evaluate(ref CurrentCell);
            }
            else
            {
                throw new Exception("No more undo");
            }

            

        }


        public void ExecuteRedo()
        {
            if (Redos.Count > 0)
            {
                UndoRedoCollection redo = Redos.Pop();
                Cell CurrentCell = this.Cells[redo.Oldcell.RowIndex, redo.Oldcell.ColumnIndex];
                AddUndo(CurrentCell, redo.PropertyName);
                redo.Evaluate(ref CurrentCell);
            }
            else
            {
                throw new Exception("No more redo");
            }
        }


        public string PeekUndo()
        {
            return this.Undos.Peek().PropertyName;
        }

        public string PeekRedo()
        {
            return this.Redos.Peek().PropertyName;
        }

        public int CountUndo()
        {
            return this.Undos.Count;
        }

        public int CountRedo()
        {
            return this.Redos.Count;
        }

        public void Clear()
        {
            Undos.Clear();
            Redos.Clear();
            for (int r = 0; r < RowCount; r++)
            {
                //loop through the columns
                for (int c = 0; c < ColumnCount; c++)
                {
                    //create a new cell from abstruct class Cell

                    Cells[r, c].ColumnIndex = c;
                    Cells[r, c].RowIndex = r;
                    Cells[r, c].Text = "";
                    Cells[r, c].BGColor = 0xFFFFFFFF;

                    //when cell OnpropertyChange it will run spreadsheet  CellPropertyChanged
                    Cells[r, c].PropertyChanged += CellPropertyChanged;
                    //this means when cell Text change, call spreadsheet CellPropertyChanged(object sender, EventArgs e)


                }
            }

        }


        public void Load(XmlReader stream)
        {
            //clear the spreadsheet
            this.Clear();
            //read the xml file
            stream.ReadToFollowing("spreadsheet");

            

            while (stream.ReadToFollowing("cell"))
            {
                //get all atributes
                string name = stream.GetAttribute("name");
                string text = stream.GetAttribute("text");
                string bgcolor = stream.GetAttribute("bgcolor");
                bool flag = true;
                string TypeName = "";

                XmlReader inner = stream.ReadSubtree();
                while (inner.Read())
                {
                    
                    switch (inner.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.Write("<{0}>", inner.Name);
                            switch (inner.Name)
                            {
                                case "text":
                                    TypeName = inner.Name;
                                    break;
                                case "bgcolor":
                                    TypeName = inner.Name;
                                    break;
                            }

                            break;
                        case XmlNodeType.Text:
                            switch (TypeName)
                            {
                                case "text":
                                    text = inner.Value;
                                    break;
                                case "bgcolor":
                                    bgcolor = inner.Value;
                                    break;
                            }
                            break;
                        case XmlNodeType.EndElement:
                            Console.Write("</{0}>", inner.Name);
                            if (inner.Name =="cell")
                            {
                                flag = false;
                            }
                            break;


                    }


                }



                //load cell to spradsheet
                //from cell name to get row and column index
                int columnIndex = name[0] - 'A';
                int rowIndex = int.Parse(name.Substring(1)) - 1;
                Cell mycell = GetCell(rowIndex, columnIndex);
                //Color.FromHex(bgcolor);
                if (bgcolor != null)
                {
                    //use color converter
                    ColorConverter converter = new ColorConverter();
                    //convert bgcolor uint to color
                    Color col = (Color)converter.ConvertFromString("#" + bgcolor);
                    //convert color to argb
                    uint i = (uint)col.ToArgb();
                    mycell.BGColor = i;

                }
                if (text != null)
                {
                    mycell.Text = text;

                }


            }
        }

        public void Save(XmlWriter stream)
        {
            //write the xml file
            stream.WriteStartElement("spreadsheet");
            //write the number of rows and columns
            stream.WriteAttributeString("rows", this.RowCount.ToString());
            stream.WriteAttributeString("columns", this.ColumnCount.ToString());
            //write the cells
            foreach (Cell cell in this.Cells)
            {
                if (cell.Text != "")
                {
                    stream.WriteStartElement("cell");
                    int columnIndex = cell.ColumnIndex + 'A';
                    int rowIndex = cell.RowIndex + 1;
                    stream.WriteAttributeString("name", ((char)columnIndex) + rowIndex.ToString());
                    stream.WriteAttributeString("text", cell.Text);

                    Color mycolor = Color.FromArgb((int)cell.BGColor);
                    string myHex = ColorTranslator.ToHtml(mycolor);


                    stream.WriteAttributeString("bgcolor", myHex.Substring(1));
                    stream.WriteEndElement();
                }
            }
            stream.WriteEndElement();
        }

        // Check if has BadRef
        public bool IsBadRef(Cell cell)
        {
            string text = cell.Text;

            // No ref exist
            if (text == "")
                return false;

            // if the text starts with an equal sign
            if (text[0] == '=')
            {

                // remove the equal sign
                string expression = text.Substring(1) + "+0";
                ExpressionTree expressionTree = new ExpressionTree(expression);
                string[] variables = expressionTree.GetVariableNames();
                foreach (string variable in variables)
                {
                    //A ~ Z
                    char column = variable[0];
                    //1 ~ 50
                    string temp = variable.Substring(1);
                    int row;
                    try
                    {
                        row = int.Parse(variable.Substring(1)) - 1;
                    }
                    catch (FormatException)
                    {
                        //unable to parse row, row is not a number
                        return true;
                    }

                    if (char.IsLetter(column) && row >= 0 && row <= 49)
                    {

                        //not bad ref
                        continue;

                    }
                    else
                    {
                        //found bad ref
                        return true;
                    }








                }
            }

                // No ref exist
                return false;

        }

        // Check if has SelfRef
        public bool IsSelfRef(Cell cell)
        {
            string text = cell.Text;

            // No ref exist
            if (text == "")
                return false;

            // if the text starts with an equal sign
            if (text[0] == '=')
            {

                // remove the equal sign
                string expression = text.Substring(1) + "+0";
            }

            // No ref exist
            return false;

        }

        // Check if has CircularRef
        public bool IsCircularRef(Cell cell)
        {
            string text = cell.Text;

            // No ref exist
            if (text == "")
                return false;

            // if the text starts with an equal sign
            if (text[0] == '=')
            {

                // remove the equal sign
                string expression = text.Substring(1) + "+0";
            }

            // No ref exist
            return false;

        }






    }
}









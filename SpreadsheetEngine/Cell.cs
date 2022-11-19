using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

//add this as reference to the Spreadsheet_Joshua_Lonhg
//but this class will not use the winform app as reference
namespace SpreadsheetEngine
{
    public abstract class Cell:INotifyPropertyChanged
    {
        protected string text;
        protected string value;
        protected uint bgColor;
        //Add a RowIndex property that is read only
        public int RowIndex { get; internal set; }
        //Add a ColumnIndex property that is read only
        public int ColumnIndex { get; internal set; }
        public Cell()
        {
            text = "";
            value = "";
            RowIndex = 0;
            ColumnIndex = 0;
            bgColor = 0xFFFFFFFF;
        }
        

        //add a string Text property y that represents the actual text that’s typed into the cell.
        public string Text { 
            get{
                return this.text;
            } 
            set{
                //ignore if text is the same
                if (this.text == value)
                    return;
                //set the text
                this.text = value;
                //fire event when text is changed
                this.OnPropertyChanged("Text");
            }
            }
        //event will store pointers to function
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            {

                //spreadsheet will catch this, and will compute value and notify Form
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

  
            }

        public void OnRefPropertyChanged(object sender, EventArgs e)
        {
                Cell changedCell = (Cell)sender;

                //spreadsheet will catch this, and will compute value and notify Form
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(changedCell.Text));


        }

        //getter only, but spreadsheet class will set it
        //spread sheet will compute text and set t
        public string Value
        {
            get;
            internal set;
        }

        public int GetRowIndex(string cellName)
        {
            //get the row index
            //get the first char
            char firstChar = cellName[0];
            //get the ascii value
            int asciiValue = (int)firstChar;
            //get the row index
            int rowIndex = asciiValue - 65;
            return rowIndex;
        }

        public int GetColIndex(string cellName)
        {
            //get the column index
            //get the last char
            char lastChar = cellName[cellName.Length - 1];
            //get the ascii value
            int asciiValue = (int)lastChar;
            //get the column index
            int colIndex = asciiValue - 65;
            return colIndex;
        }

        public uint BGColor
        {
            get
            {
                return this.bgColor;

            }
            set
            {
                if (this.bgColor == value)
                    return;
                this.bgColor = value;
                //fire event when color is changed
                this.OnPropertyChanged("BGColor");

            }
        }

    }

    


        
}


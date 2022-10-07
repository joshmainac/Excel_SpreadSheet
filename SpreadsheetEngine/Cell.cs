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
        //Add a RowIndex property that is read only
        public int RowIndex { get; private set; }
        //Add a ColumnIndex property that is read only
        public int ColumnIndex { get; private set; }
        public Cell()
        {
            text = "";
            value = "";
            RowIndex = 0;
            ColumnIndex = 0;
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
                //fire property changed event
                this.OnPropertyChanged("Text");
            }
            }


        //getter only, but spreadsheet class will set it
        public string Value
        {
            get;
            internal set;
        }



        public event PropertyChangedEventHandler PropertyChanged;



        protected void OnPropertyChanged(string name)
            {
                //PropertyChangedEventHandler handler = PropertyChanged;
                //if (handler != null)
                //{
                //    handler(this, new PropertyChangedEventArgs(name));
                //}

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

                //if(PropertyChanged != null)
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs(name));
                //}
            }
            
    }

    


        
}


    //Make a  class implement the INotifyPropertyChanged interface (declared in the System.ComponentModel namespace)
    // public class Cell2 : INotifyPropertyChanged
    // {
    //     //Add a PropertyChanged event that is raised when the Text property changes
    //     public event PropertyChangedEventHandler PropertyChanged;
    //     //Add a protected virtual OnPropertyChanged method that raises the PropertyChanged event
    //     protected virtual void OnPropertyChanged(string propertyName)
    //     {
    //         if (PropertyChanged != null)
    //             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    //     }
    // }
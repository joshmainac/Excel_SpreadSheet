using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    class UndoRedoCollection
    {
        Cell oldcell;
        //get row and column from oldcell
        int row;
        int column;

        



        public Cell Oldcell
        {
            get { return oldcell; }
            set { oldcell = value; }
        }

        public UndoRedoCollection(Cell oldcell)
        {
            this.oldcell = oldcell;
            //get row and column from oldcell
            this.row = oldcell.RowIndex;
            this.column = oldcell.ColumnIndex;
        }

        public void Evaluate(ref Cell senderCell)
        {
            senderCell.Text = this.oldcell.Text;
            senderCell.BGColor = this.oldcell.BGColor;
        }




    }
}

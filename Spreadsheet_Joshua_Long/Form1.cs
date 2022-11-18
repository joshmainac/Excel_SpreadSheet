using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SpreadsheetEngine;

namespace Spreadsheet_Joshua_Long
{
    public partial class Form1 : Form
    {
        private Spreadsheet spreadsheet;
        //HW8
        public System.Drawing.Color BackColor { get; set; }
        ///
        public Form1()
        {
            InitializeComponent();
            InitializeDataGrid();
            spreadsheet = new Spreadsheet(50, 26);
            spreadsheet.PropertyChanged += UpdateGrid;
            this.undoTextChangeToolStripMenuItem.Enabled = false;
            this.redoTextChangeToolStripMenuItem.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeDataGrid()
        {
            //clear
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            //InitializeDataGridView();

            //Step 1 – Create Columns A to Z with code:
            for (int i = 0; i < 26; i++)
            {
                dataGridView1.Columns.Add(Convert.ToChar(i + 65).ToString(), Convert.ToChar(i + 65).ToString());
            }

            //Step 2 – Create Rows 1 to 50:
            for (int i = 0; i < 50; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

   




        }



        private void UpdateGrid(object sender, EventArgs e)
        {

            Cell changedCell = (Cell)sender;
            //update value
            dataGridView1.Rows[changedCell.RowIndex].Cells[changedCell.ColumnIndex].Value = changedCell.Value;

            //update color
            dataGridView1.Rows[changedCell.RowIndex].Cells[changedCell.ColumnIndex].Style.BackColor = Color.FromArgb((int)changedCell.BGColor);




        }















        //can copy numers but not Text
        private void button1_Click(object sender, EventArgs e)
        {
            // set the text in about 50 random cells to a text string of your choice
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                int row = random.Next(0, 50);
                int col = random.Next(0, 26);
                spreadsheet.GetCell(row, col).Text = "=1+1";
            }
            //do a loop to set the text in every cell in column B to “This is cell B#”, where # number is the row number for the cell
            for (int i = 0; i < 50; i++)
            {
                //dataGridView1[1, i].Value = 
                spreadsheet.GetCell(i, 1).Text = "10";
            }

            for (int i = 0; i < 50; i++)
            {
                //dataGridView1[0, i].Value = "=B" + (i + 1);
                spreadsheet.GetCell(i, 0).Text = "=B" + (i + 1);
            }






        }

        private void dataGridView1_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).Text;


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //add previous cell to undo stack
            spreadsheet.AddUndo(spreadsheet.GetCell(e.RowIndex, e.ColumnIndex));
            this.undoTextChangeToolStripMenuItem.Enabled = true;
            this.undoTextChangeToolStripMenuItem.Text = "Undo" + spreadsheet.PeekUndo();


            //update spreadsheet Cells from dataGridView1 changing formula
            spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();




            // Make sure that when a cell is changed all other cells that reference that cell in their formulas get
            // updated. This means that the cell Text property change is not the only circumstance where you need to
            // update its value.
            //spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).PropertyChanged += CellPropertyChanged;










            //set the excel grid to the cell value
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).Value;


        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.Blue;
            //dataGridView1.celec
        }

        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows[0].Cells[2].Style.BackColor = Color.Blue;
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = dataGridView1.Rows[0].Cells[2].Style.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                uint i = (uint)MyDialog.Color.ToArgb();
                //loop for all selected cells
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    
                    spreadsheet.GetCell(cell.RowIndex, cell.ColumnIndex).BGColor = i;




                }

            }
       



               


        }

        private void undoTextChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spreadsheet.ExecuteUndo();
            if (spreadsheet.CountUndo() == 0)
            {
                this.undoTextChangeToolStripMenuItem.Enabled = false;
            }
            this.redoTextChangeToolStripMenuItem.Enabled = true;
        }

        private void redoTextChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spreadsheet.ExecuteRedo();
            if (spreadsheet.CountRedo() == 0)
            {
                this.redoTextChangeToolStripMenuItem.Enabled = false;
            }
            this.undoTextChangeToolStripMenuItem.Enabled = true;
        }
    }
}


     
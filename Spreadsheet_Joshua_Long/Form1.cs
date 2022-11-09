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
        public Form1()
        {
            InitializeComponent();
            InitializeDataGrid();
            spreadsheet = new Spreadsheet(50, 26);
            spreadsheet.PropertyChanged += UpdateGrid;
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
 
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = spreadsheet.GetCell(i,j).Value;
                }
            }

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
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).Value;

        }
    }
}


     
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spreadsheet_Joshua_Long
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGrid();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //mod a spread sheet object

        }
    }
}

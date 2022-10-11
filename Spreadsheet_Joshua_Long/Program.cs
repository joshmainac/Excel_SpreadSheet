using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SpreadsheetEngine;



namespace Spreadsheet_Joshua_Long
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //int A = 0;
            //Spreadsheet obj1 = new Spreadsheet(26, 50);
            //obj1.Cells[0, 0].Text = "joshua";
            //obj1.PropertyChanged += CellPropertyChanged;
            //obj1.Cells[0, 0].Text = "joshua";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        static void CellPropertyChanged(object sender, EventArgs e)
        {

            Console.WriteLine("llll");

        }
    }
}

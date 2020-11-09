using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class ResultForm : Form
    {
        public ResultForm(ref int[,] resultArray)
        {
            InitializeComponent();
            displayAllValues(this, ref resultArray);
        }
        static public void displayAllValues(Form f, ref int[,] resultArray)            //read from all the textboxes row by row, starting from top left corner
        {
            int i = 0, j = 0;
            foreach (var control in f.Controls)
            {
                if (control.GetType().Name == "TextBox")
                {
                    var textBox = control as TextBox;
                    textBox.Text = resultArray[i, j].ToString();
                    ++i;
                    if (i % 9 == 0 && i != 0)
                    {
                        i = 0;
                        ++j;
                    }            
                }
            }
        }
    }
}

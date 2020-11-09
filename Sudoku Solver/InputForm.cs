using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Sudoku_Solver
{    
    public partial class InputForm : Form
    {
        ResultForm rf;
        int[,] values = new int[9, 9];
        public InputForm()
        {
            InitializeComponent();
            
        }
        
        private void SolveButton_Click(object sender, EventArgs e)
        {
            Helper.readTextBoxes(this, ref values);

            if(Helper.findSolution(ref values))
            {
                closeOpenResultForm();
                rf = new ResultForm(ref values);
                rf.Show();
            }
            else
            {
                MessageBox.Show("Given sudoku is impossible to solve.", "Failure");
            }            
        }
        private void closeOpenResultForm()
        {
            FormCollection forms = Application.OpenForms;

            foreach (Form form in forms)
            {
                if (form.Name == "ResultForm")
                {
                    form.Close();
                    break;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Helper.clearTextBoxes(this);
        }
    }
}

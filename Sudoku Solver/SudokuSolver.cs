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
    public partial class SudokuSolver : Form
    {
        List<int> initialPossibleValue = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9};
        List<int>[,] possibleValues = new List<int>[9, 9];         //stores a list of possible values in each field

        int[,] values = new int[9, 9];
        public SudokuSolver()
        {
            InitializeComponent();
        }

        
        private void SolveButton_Click(object sender, EventArgs e)
        {
            Helper.populatePossibleValues(ref possibleValues, initialPossibleValue);
            Helper.getAllValues(this);
        }

      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public static class Helper
    {        
        static public void getAllValues(Form f)            //read from all the textboxes row by row, starting from top left corner
        {            
            foreach(var control in f.Controls)
            {
                if (control.GetType().Name == "TextBox")
                {
                    var textBox = control as TextBox;
                }
            }
        }

        static public void populatePossibleValues(ref List<int>[,] array, List<int> initialVector)       //initialize the 2d array with possible values for each field
        {
            for(int i = 0; i < array.GetLength(1); ++i)
            {
                for (int j = 0; j < array.GetLength(0); ++j)
                {
                    array[i, j] = initialVector;
                }
            }
        }
            
    }
}

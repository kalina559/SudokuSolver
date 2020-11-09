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
        static public void readTextBoxes(Form f, ref int[,] resultArray)            //read from all the textboxes row by row, starting from top left corner
        {
            int i = 0, j = 0;
            foreach(var control in f.Controls)
            {
                if (control.GetType().Name == "TextBox")
                {
                    var currentCellValue = getTextBoxDigit(control);
                    resultArray[i, j] = currentCellValue;      

                    ++i;
                    if(i % 9 == 0 && i != 0)
                    {
                        i = 0;
                        ++j;
                    }
                }
            }
        }
        static public bool findSolution(ref int[,] array)
        {
            return fillNextEmptyField(ref array);
        }
        static public bool fillNextEmptyField(ref int[,] resultArray)
        {
            var indexPair = getNextEmptyField(ref resultArray);
            int x = indexPair.Item1;
            int y = indexPair.Item2;

            if (x == -1 && y == -1 )   //that means that getNextEmptyField() method went through the whole array without finding an empty field => sudoku has been solved
            {
                return true;
            }

            for (int v = 1; v <= 9; ++v)
            {                
                if (checkIfValuePossible(x, y, v, ref resultArray))
                {
                    resultArray[x, y] = v;

                    if (fillNextEmptyField(ref resultArray))
                    {
                        return true;
                    }
                    resultArray[x, y] = 0;
                }
            }
            return false;
        }

        static Tuple<int, int> getNextEmptyField(ref int[,] resultArray)
        {
            for(int i = 0; i < 9; ++i)
            {                
                for (int j = 0; j < 9; ++j)
                {
                    if (resultArray[i, j] == 0)
                    {
                        return (new Tuple<int, int>(i, j));
                    }                    
                }
            }
            return (new Tuple<int, int>(-1, -1));
        }

        static public bool checkIfValuePossible(int i, int j, int value, ref int[,] resultArray)
        {
            return (checkIfValuePossibleRow(i, value, ref resultArray)
                    && checkIfValuePossibleColumn(j, value, ref resultArray)
                    && checkIfValuePossibleMatrix(i, j, value, ref resultArray));

        }
        static public bool checkIfValuePossibleRow(int rowIndex, int value, ref int[,] resultArray)
        {            
            for(int j = 0; j < 9; ++j)
            {
                if (resultArray[rowIndex, j] == value)
                    return false;
            }
            return true;
        }

        static public bool checkIfValuePossibleColumn(int columnIndex, int value, ref int[,] resultArray)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (resultArray[i, columnIndex] == value)
                    return false;
            }
            return true;
        }

        static public bool checkIfValuePossibleMatrix(int rowIndex, int columnIndex, int value, ref int[,] resultArray)
        {
            int rowNumber, columnNumber;

            rowNumber = rowIndex / 3;
            columnNumber = columnIndex / 3;            

            for (int i = rowNumber * 3 ; i < rowNumber * 3 + 3; ++i)
            {
                for (int j = columnNumber * 3 ; j < columnNumber * 3 + 3; ++j)
                {
                    if (resultArray[i, j] == value)
                        return false;
                }
            }
            return true;
        }        

        static public bool isTextBoxDigit(TextBox textBox)
        {
            return (textBox.Text.Length == 1
                && char.Parse(textBox.Text) >= '1'
                && char.Parse(textBox.Text) <= '9');
        }

        static public int getTextBoxDigit(object control)
        {
            var textBox = control as TextBox;
            if (isTextBoxDigit(textBox))
            {
                return int.Parse(textBox.Text);
            }
            else
            {
                return 0;
            }
        }

        //functions below are just for debug purposes
        static public void showMessageBox(string myString, string formName)
        {
            MessageBox.Show(myString, formName);
        }

        static public string differentIndexes(int[,] resultArray, int[,] expectedArray)
        {
            string indexes = "";
            for(int i = 0; i < resultArray.GetLength(0); ++i)
            {
                for (int j = 0; j < resultArray.GetLength(1); ++j)
                {
                    if(resultArray[i,j] != expectedArray[i,j])
                    {
                        indexes += "i: " + i.ToString() + " j: " + j.ToString() + "\n";
                    }
                }
            }
            return indexes;
        }

        static public string arrayToString(int[,] array)
        {
            string arrayString = "";
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    if (j % 3 == 0)
                    {
                        arrayString += "   ";
                    }
                    arrayString += array[i, j].ToString() + ", ";
                }
                arrayString += "\n";
            }

            return arrayString;
        }
    }
}

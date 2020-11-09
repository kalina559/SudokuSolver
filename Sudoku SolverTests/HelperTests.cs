using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku_Solver.Tests
{
    [TestClass()]
    public class HelperTests
    {
        [TestMethod()]
        public void analyzeArrayTest()
        {           

            int[,] resultArray1 = new int[9, 9]
            {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            int[,] resultArray2 = new int[9, 9]
            {
                { 0, 0, 0, 0, 0, 0, 2, 0, 0 },
                { 0, 8, 0, 0, 0, 7, 0, 9, 0 },
                { 6, 0, 2, 0, 0, 0, 5, 0, 0 },
                { 0, 7, 0, 0, 6, 0, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 2, 0, 0, 4, 0 },
                { 0, 0, 5, 0, 0, 0, 6, 0, 3 },
                { 0, 9, 0, 4, 0, 0, 0, 7, 0 },
                { 0, 0, 6, 0, 0, 0, 0, 0, 0 }
            };


            int[,] expectedArray1 = new int[9, 9]
            {
                {3, 1, 6, 5, 7, 8, 4, 9, 2},
                {5, 2, 9, 1, 3, 4, 7, 6, 8},
                {4, 8, 7, 6, 2, 9, 5, 3, 1},
                {2, 6, 3, 4, 1, 5, 9, 8, 7},
                {9, 7, 4, 8, 6, 3, 1, 2, 5},
                {8, 5, 1, 7, 9, 2, 6, 4, 3},
                {1, 3, 8, 9, 4, 7, 2, 5, 6},
                {6, 9, 2, 3, 5, 1, 8, 7, 4},
                {7, 4, 5, 2, 8, 6, 3, 1, 9}
            };

            int[,] expectedArray2 = new int[9, 9]
            {
                {9, 5, 7, 6, 1, 3, 2, 8, 4},
                {4, 8, 3, 2, 5, 7, 1, 9, 6},
                {6, 1, 2, 8, 4, 9, 5, 3, 7},
                {1, 7, 8, 3, 6, 4, 9, 5, 2},
                {5, 2, 4, 9, 7, 1, 3, 6, 8},
                {3, 6, 9, 5, 2, 8, 7, 4, 1},
                {8, 4, 5, 7, 9, 2, 6, 1, 3},
                {2, 9, 1, 4, 3, 6, 8, 7, 5},
                {7, 3, 6, 1, 8, 5, 4, 2, 9}
            };
            Helper.findSolution(ref resultArray1);
            Helper.findSolution(ref resultArray2);

            //Helper.showMessageBox(Helper.arrayToString(resultArray) + "\n \n \n" + Helper.arrayToString(expectedArray), "Array display");
            //Helper.showMessageBox(Helper.differentIndexes(resultArray, expectedArray), "Indexes with different values");

            CollectionAssert.AreEqual(resultArray1, expectedArray1);
            CollectionAssert.AreEqual(resultArray2, expectedArray2);
        }

        [TestMethod()]
        public void analyzeArrayUnsolvable()
        {
            int[,] resultArray = new int[9, 9]
            {
                {0, 1, 2, 3, 4, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {6, 8, 7, 0, 0, 0, 0, 3, 1},
                {7, 0, 3, 0, 1, 0, 0, 8, 0},
                {8, 0, 0, 8, 6, 3, 0, 0, 5},
                {9, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            Assert.AreEqual(Helper.findSolution(ref resultArray), false);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Utils
    {
        public static bool[,] createMatrix()//Filing the dairy with false valuse
        {
            bool[,] mat = new bool[12, 31];
            for (int i = 0; i < 12; i++)//This for fills the array with false values
            {
                for (int j = 1; j < 31; j++)
                {
                    mat[i, j] = false;
                }
            }
            return mat;
        }
    }
}

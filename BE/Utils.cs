using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace BE
{
    public class Utils
    {

        /// <summary>
        /// Filing the dairy with false valuse
        /// </summary>
        /// <returns>the update matrix</returns>
        public static bool[,] createMatrix()
        {
            bool[,] mat = new bool[12, 31];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 1; j < 31; j++)
                {
                    mat[i, j] = false;
                }
            }
            return mat;
        }

        static public NavigationService navigationService { get; set; }
    }
}

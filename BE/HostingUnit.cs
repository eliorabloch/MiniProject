using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class HostingUnit
    {
        
        public int HostingUnitKey;
        Host Owner { get; set; }
        string HostingUnitName { get; set; }
        bool[,] Diary { get; set; }
        string toString { get; set; }
        public void FillMatrix(bool[,] d)//Filing the dairy with false valuse
        {
            for (int i = 0; i < 12; i++)//This for fills the array with false values
            {
                for (int j = 1; j < 31; j++)
                {
                    Diary[i, j] = false;
                }
            }
        }
        public HostingUnit(Order newOrder)//Constructor.
        {
            Diary = new bool[12, 31];// Matrix of hotel capacity.
            FillMatrix(Diary);
            HostingUnitKey = Order.HostingUnitKey;
          //  HostingUnitKey++;  
            
        }
        public HostingUnit()//Constructor.
        {
            Diary = new bool[12, 31];// Matrix of hotel capacity.
            FillMatrix(Diary);
            

        }


    }
}

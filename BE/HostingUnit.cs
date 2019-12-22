using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class HostingUnit
    {
        int ID;
        public int HostingUnitKey;
        Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        public bool[,] Diary { get; set; }
        public string toString { get; set; }
        public bool Pool;
        public bool Jacuzz;
        public  bool Garden;
        public  bool ChildrensAttractions;
        public Areas Area;
        string SubArea;
        public UnitType Type;
        public HostingUnit() { }//defult constructor
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
    }
}

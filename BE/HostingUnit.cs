using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class HostingUnit : ICloneable
    {
        int ID;
        private int hostingUnitKey;
        public int HostingUnitKey
        {
            private set
            {
                hostingUnitKey = Configuration.HostingUnitId++;
            }
            get
            {
                return hostingUnitKey;
            }
        }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        private bool[,] diary;
        public bool[,] Diary {
            set {
                diary = createMatrix();
            }
            get
            {
                return diary;
            }
        }
        public string toString { get; set; }
        public bool Pool;
        public bool Jacuzz;
        public  bool Garden;
        public  bool ChildrensAttractions;
        public Areas Area;
        string SubArea;
        public UnitType Type;
        public HostingUnit() { }//defult constructor
        private bool[,] createMatrix()//Filing the dairy with false valuse
        {
            bool[,] d = new bool[12, 31];
            for (int i = 0; i < 12; i++)//This for fills the array with false values
            {
                for (int j = 1; j < 31; j++)
                {
                    d[i, j] = false;
                }
            }
            return d;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

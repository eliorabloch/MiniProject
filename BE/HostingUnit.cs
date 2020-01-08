using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class HostingUnit : ICloneable
    {
        public int HostingUnitKey
        {
            set;
            get;
        }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        public bool[,] Diary;
        public bool Pool;
        public bool Jacuzz;
        public  bool Garden;
        public  bool ChildrensAttractions;
        public bool FreeParking;
        public bool breakfastIncluded;
        public bool AirConditoiner;
        public bool RoomService;
        public Areas Area;
        public string SubArea;
        public UnitType Type;
        public HostingUnit() { }//defult constructor
        
        public object Clone()
        {
            return MemberwiseClone();
        }
        public override string ToString()//A print function that prints all the details of the class
        {
            string toString = "";
            toString += "This is your hostingUnit information: \n";
            toString += $"Hosting unit key: {HostingUnitKey} \n";
            toString += $"Owner: {Owner} \n";
            toString += $"Hosting unit name: {HostingUnitName} \n";
            toString += $"Pool?: {Pool} \n";
            toString += $"Jacuzzi?: {Jacuzz} \n";
            toString += $"Garden?: {Garden} \n";
            toString += $"Childrens attractions?: {ChildrensAttractions} \n";
            toString += $"Area: {Area} \n";
            toString += $"Sub area: {SubArea} \n";
            return toString;
        }
    }
}

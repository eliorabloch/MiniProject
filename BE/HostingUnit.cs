using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class HostingUnit : ICloneable
    {
        public int HostingUnitKey { get; set; }
        public Host Owner { get; set; }
        public bool Pool{ get; set; }
        public bool Jacuzz{ get; set; }
        public bool Garden{ get; set; }
        public bool ChildrensAttractions { get; set; }
        public bool FreeParking { get; set; }
        public bool breakfastIncluded { get; set; }
        public bool AirConditoiner { get; set; }
        public bool RoomService { get; set; }
        public string HostingUnitName { get; set; }
        public Areas Area { get; set; }
        public string SubArea { get; set; }
        public UnitType Type { get; set; }
        public int RateStars { get; set; }
        public int RateAmount { get; set; }
        public int amountOfRaters { get; set; }
        
        
        public bool[,] Diary;

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
            toString += $"Room Service?: { RoomService} \n";
            toString += $"Air Conditoiner?: { AirConditoiner } \n";
            toString += $"breakfast Included?: {breakfastIncluded} \n";
            toString += $"Free Parking?: {FreeParking} \n";
            return toString;
        }
    }
}

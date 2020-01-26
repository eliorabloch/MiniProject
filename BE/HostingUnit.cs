using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    [XmlRoot(ElementName = "ArrayOfHostingUnit")]
    public class HostingUnits : List<HostingUnit> { }


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

        [XmlIgnore]
        public bool[,] Diary { get; set; }
        [XmlArray("Diary")]
        public bool[] FlatDiary
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12); } //5 is the number of roes in the matrix
        }
    
        public HostingUnit() { }
        
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// A print function that prints all the details of the class
        /// </summary>
        /// <returns>the hosting unit details./</returns>
        public override string ToString()
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

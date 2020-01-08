using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest : ICloneable
    {
        public int GuestRequestKey
        {
            get; set;
        }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public RequestStatus Status {get ;set;}
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Areas Area { get; set; }
        public string SubArea { get; set; }
        public UnitType Type { get; set; }
        public string Adults { get; set; }
        public string Children { get; set; }
        public Options Pool { get; set; }
        public Options FreeParking{ get; set; }
        public Options breakfastIncluded { get; set; }
        public Options AirConditoiner { get; set; }
        public Options RoomService { get; set; }
       

        public Options Jacuzzi { get; set; }
        public Options Garden { get; set; }
        public Options ChildrensAttractions { get; set; }
        public GuestRequest() { }// defualt constructor
        public override string ToString()//A print function that prints all the details of the class
        {
            string toString = "";
            toString += "This is your guest request information: \n";
            toString += $"Private name: {PrivateName} \n";
            toString += $"Family name: {FamilyName} \n";
            toString += $"Mail address: {MailAddress} \n";
            toString += $"Status: {Status} \n";
            toString += $"Entry date: {EntryDate.Date.ToString("dd-MM-yyyy")} \n";
            toString += $"Release date: {ReleaseDate.Date.ToString("dd-MM-yyyy")} \n";
            toString += $"Registration Date: {RegistrationDate.Date.ToString("dd-MM-yyyy")} \n";
            toString += $"Area: {Area} \n";
            toString += $"Sub area: {SubArea} \n";
            toString += $"Type: {Type} \n";
            toString += $"Adults: {Adults} \n";
            toString += $"Children: {Children} \n";
            toString += $"Pool?: {Pool} \n";
            toString += $"Jacuzzi?: {Jacuzzi} \n";
            toString += $"Garden?: {Garden} \n";
            toString += $"Childrens attractions?: {ChildrensAttractions} \n";
            toString += $" Room Service?: { RoomService} \n";
            toString += $"Air Conditoiner?: { AirConditoiner } \n";
            toString += $"breakfast Included?: {breakfastIncluded} \n";
            toString += $"Free Parking?: {FreeParking} \n";
            return toString;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}


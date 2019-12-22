using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {

        public int GuestRequestKey { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public string unitType;
        public string Status{get;set;}
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Areas Area { get; set; }
        public string SubArea { get; set; }
        public UnitType Type { get; set; }
        public string Adults { get; set; }
        public string Children { get; set; }
        public hotelAdditions Pool { get; set; }
        public hotelAdditions Jacuzz { get; set; }
        public hotelAdditions Garden { get; set; }
        public hotelAdditions ChildrensAttractions { get; set; }
        public string toString { get; set; }

        public GuestRequest() { }
        public override string ToString()
        {
            toString = "";
            toString += "this is your request information: \n";
            toString
                += $"entry date: {EntryDate} \n";
            toString += $"Realese date: {ReleaseDate} \n";
            return toString;


        }






    }
}


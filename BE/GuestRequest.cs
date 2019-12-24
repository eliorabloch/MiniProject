using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest : ICloneable
    {
        private int guestRequestKey;
        public int GuestRequestKey
        {
            get { return guestRequestKey; }
            private set
            {
                guestRequestKey = Configuration.GuasteRequestId++;
            }
        }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public RequestStatus Status {get;set;}
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Areas Area { get; set; }
        public string SubArea { get; set; }
        public UnitType Type { get; set; }
        public uint Adults { get; set; }
        public uint Children { get; set; }
        public Options Pool { get; set; }
        public Options Jacuzz { get; set; }
        public Options Garden { get; set; }
        public Options ChildrensAttractions { get; set; }
        public string toString { get; set; }
        public GuestRequest() { }// defualt constructor
        public override string ToString()
        {
            toString = "";
            toString += "this is your request information: \n";
            toString += $"entry date: {EntryDate} \n";
            toString += $"Realese date: {ReleaseDate} \n";
            return toString;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}


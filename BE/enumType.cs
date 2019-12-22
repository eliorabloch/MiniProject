using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public enum UnitType
    {
        Tzimer, HostingUnit, HotelRoom, Tent
    }
   public enum Areas
    {
        South, North, Center, Jerusalem
    }
    public enum OrderStatus
    {
        NotHandled, SentMail, ClosedRequest, ConfirmedClosedRequest
    }
   public  enum RequestStatus
    {
        Open, ClosedDeal, ExpiredRequest
    }
    public enum hotelAdditions
    {
        neccesery, possible,notintersted
    }
}

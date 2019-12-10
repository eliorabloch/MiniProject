using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    enum UnitType
    {
        Tzimer, HostingUnit, HotelRoom, Tent
    }
    enum Areas
    {
        South, North, Center, Jerusalem
    }
    enum OrderStatus
    {
        NotHandled, SentMail, ClosedRequest, ConfirmedClosedRequest
    }

    enum RequestStatus
    {
        Open, ClosedDeal, ExpiredRequest
    }
}

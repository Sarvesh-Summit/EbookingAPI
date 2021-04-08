using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBookingCompleteAPI.Models
{
    public class ReceiptInfo
    {
        public string AgencyID { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string CasualAddress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string AgencyName { get; set; }
    }

    public class PendingROIDInfo
    {
        public string ROID { get; set; }
        public string Net { get; set; }
    }

    public class AdvanceReceiptInfo
    {
        public string ReceiptID { get; set; }
        public double BalanceAmount { get; set; }
    }
}
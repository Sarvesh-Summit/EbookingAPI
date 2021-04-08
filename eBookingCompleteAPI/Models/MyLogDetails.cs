using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBookingCompleteAPI.Models
{
    public class MyLogDetails
    {
        public int AgencyId { get; set; }
        public int Roid { get; set; }
        public int Bookingexeid { get; set; }
        public int Packegid { get; set; }
        public int StatusId { get; set; }
        public int ClientId { get; set; }
        public string RoNumber { get; set; }
        public int CanvassorId { get; set; }
        public int date { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string ApiName { get; set; }
        public string ParameterName { get; set; }
        public int UserId { get; set; }
        public int IsClassified { get; set; }

    }

    public class MyLoggridDetails
    {
        public int SNo { get; set; }
        public string RoNumber { get; set; }
        public string BookingID { get; set; }
        public string AgencyName { get; set; }
        public string ClientName { get; set; }
        public string ScheduleDate { get; set; }
        public string packageName { get; set; }
        public string Adsize { get; set; }
        public string PremiaName { get; set; }
        public string ColorName { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string Resend { get; set; }
        public string RejectionReason { get; set; }
        public string RejectionNote { get; set; }
        public string ROID { get; set; }
        public string BookingDate { get; set; }
        public string AdtypeName { get; set; }
        public string Cat1 { get; set; }
        public string Cat2 { get; set; }
        public string Cat3 { get; set; }
        public string Cat4 { get; set; }
        public string BookingExecName { get; set; }
        public string CanvassorName { get; set; }
        public string AgencyExec { get; set; }


 

    }
}
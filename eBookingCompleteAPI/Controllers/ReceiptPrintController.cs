using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class ReceiptPrintController : ApiController
    {

        HomeDAL objHomeDAL = new HomeDAL();
        public IEnumerable<PrintData> Post(PrintData objbookingDetail)
        {
            List<PrintData> objListcontroldata = new List<PrintData>();
            try
            {
                bool IsCheck = IsClassified(Convert.ToInt32(objbookingDetail.ReceiptId));
                PrintData obj = new PrintData();
                obj.ReceiptId = objbookingDetail.ReceiptId;
                obj.IsCheckType = IsCheck;

                objListcontroldata.Add(obj);


            }
            catch (Exception ex)
            {
            }
            return objListcontroldata;
        }
        private bool IsClassified(int ReceiptNo)
        {

            string query = "select IsClassified from tbl_booking(NOlock) INNER JOIN TBL_Booking_Receipt ON tbl_booking.ROID=TBL_Booking_Receipt.ROID where TBL_Booking_Receipt.ReceiptID=" + ReceiptNo + "";
            DataTable dt = objHomeDAL.eBookingIsCheckprint(query).Tables[0];
            if (dt.Rows.Count > 0 && dt.Rows[0]["IsClassified"].ToString() == "1")
                return true;
            else
                return false;


        }

    }
}

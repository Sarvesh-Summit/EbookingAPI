using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetUserRightController : ApiController
    {
        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>getuserrights</actionname>"
                                + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                               + "<revenuecentreid>" + objbookingDetail.RevenueCentreID + "</revenuecentreid>"
                               + "</ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                   // objcontroldata.AllowBooking = Convert.ToInt32(dr["AllowBooking"]);
                    objcontroldata.AllowDisplayBooking = Convert.ToInt32(dr["AllowDisplayBooking"]);
                    objcontroldata.AllowClassifiedBooking = Convert.ToInt32(dr["AllowClassifiedBooking"]);
                    objcontroldata.AllowCreditBooking = Convert.ToInt32(dr["AllowCreditBooking"]);
                    objcontroldata.AllowManualBooking = Convert.ToInt32(dr["AllowManualBooking"]);
                    objcontroldata.AllowSuspendOrder = Convert.ToInt32(dr["AllowSuspendOrder"]);
                    objcontroldata.AllowCancelOrder = Convert.ToInt32(dr["AllowCancelOrder"]);
                    objcontroldata.AllowReceiptCancellation = Convert.ToInt32(dr["AllowReceiptCancellation"]);
                    objcontroldata.AllowVATModification = Convert.ToInt32(dr["AllowVATModification"]);
                    objcontroldata.AllowWTModification = Convert.ToInt32(dr["AllowWTModification"]);
                    objcontroldata.IsBrandNecessary = Convert.ToInt32(dr["isBrandNecessary"]);
                    objcontroldata.IsProductNecessary = Convert.ToInt32(dr["isProductNecessary"]);
                    objListcontroldata.Add(objcontroldata);
                }
            }
            catch (Exception ex)
            {
            }
            return objListcontroldata;
        }
    }
}

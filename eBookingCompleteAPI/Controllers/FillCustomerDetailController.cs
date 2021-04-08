using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillCustomerDetailController : ApiController
    {

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public string Post(BookingDetail objbookingDetail)
        {
            string CustomerName = string.Empty;
            try
            {
                string strXml = "<ebooking><actionname>customerdetails</actionname>"
                               + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<logcentreid>" + objbookingDetail.RevenueCentreID + "</logcentreid>"
                              + "</ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingUserDetails(strXml).Tables[0];
                foreach (DataRow dr in objdt.Rows)
                {
                    CustomerName = Convert.ToString(dr[2]);
                }
            }
            catch (Exception ex)
            {
            }
            return CustomerName;
        }

    }
}

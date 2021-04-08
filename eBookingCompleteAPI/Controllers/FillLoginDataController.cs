using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillLoginDataController : ApiController
    {

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public BookingDetail Post(BookingDetail objbookingDetail)
        {
            try
            {
                string strXml = "select u.UserName,c.CentreName from TBL_USER as u , TBL_CENTRE as c where u.userid=" + objbookingDetail.UserId + " and c.CentreID="+ objbookingDetail.RevenueCentreID + "";
                DataTable objdt = objHomeDAL.GeteBookingLoginData(strXml).Tables[0];
                foreach (DataRow dr in objdt.Rows)
                {
                    objbookingDetail.UserName = Convert.ToString(dr[0]);
                    objbookingDetail.CentreName = Convert.ToString(dr[1]);
                }
            }
            catch (Exception ex)
            {
            }
            return objbookingDetail;
        }
    }
}

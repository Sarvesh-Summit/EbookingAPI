using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillPendingOrdersController : ApiController
    {

        // GET: GetControlData

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.Parametername + "</actionname>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<revenuecentreid>" + objbookingDetail.RevenueCentreID + "</revenuecentreid></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.PendingROID = Convert.ToString(dr["ROID"]);
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

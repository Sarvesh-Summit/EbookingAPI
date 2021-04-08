using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillAgencyControlDataController : ApiController
    {
        // GET: GetControlData

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.Parametername + "</actionname><agencyname>" + objbookingDetail.ParamValueStr + "</agencyname>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.ID = Convert.ToInt32(dr[0]);
                    objcontroldata.Value = Convert.ToString(dr[1]);
                    objcontroldata.DisplayRateCardID = Convert.ToInt32(dr[3]);
                    objcontroldata.ClassifiedRateCardID = Convert.ToInt32(dr[4]);
                    objcontroldata.DisplayCommissionID = Convert.ToInt32(dr[5]);
                    objcontroldata.ClassifiedCommissionID = Convert.ToInt32(dr[6]);
                    objcontroldata.AllowCasualClient = Convert.ToInt32(dr[7]);
                    objcontroldata.AgencyPaymentmode = Convert.ToInt32(dr[8]);
                    objcontroldata.EmbargoID = Convert.ToInt32(dr[9]);
                    objcontroldata.EmbargoReason = Convert.ToString(dr[10]);
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

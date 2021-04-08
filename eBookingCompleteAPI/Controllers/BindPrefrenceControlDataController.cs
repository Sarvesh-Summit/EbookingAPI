using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class BindPrefrenceControlDataController : ApiController
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
                              + "<isdigital>" + objbookingDetail.IsDigital + "</isdigital></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.BackBookingDays = Convert.ToInt32(dr[0]);
                    objcontroldata.WriteOffAmount = Convert.ToDouble(dr[1]);
                    objcontroldata.MaxDiscountForAutoApproval = Convert.ToDouble(dr[2]);
                    objcontroldata.TextTypingInBooking = Convert.ToInt32(dr[3]);
                    objcontroldata.AutoFolderCreationforClassifiedorders = Convert.ToInt32(dr[4]);
                    objcontroldata.IsSMENecessaryForBookingOrder = Convert.ToInt32(dr[5]);
                    objcontroldata.isMaterialTypeRequired = Convert.ToInt32(dr[6]);
                    objcontroldata.DefaultColorForDispAd = Convert.ToInt32(dr[7]);
                    objcontroldata.DisplayUOM = Convert.ToInt32(dr[8]);
                    objcontroldata.DefaultPkgID = Convert.ToInt32(dr[9]);
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

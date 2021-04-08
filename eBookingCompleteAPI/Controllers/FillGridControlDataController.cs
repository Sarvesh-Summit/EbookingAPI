using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillGridControlDataController : ApiController
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
                              +"<packageidlist>" + objbookingDetail.PackageID + "</packageidlist>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.InsNumber = Convert.ToInt32(dr[0]);
                    objcontroldata.PackageID = Convert.ToInt32(dr[1]);
                    objcontroldata.PackageName = Convert.ToString(dr[2]);
                    objcontroldata.PEID = Convert.ToInt32(dr[3]);
                    objcontroldata.PECode = Convert.ToString(dr[4]);
                    objcontroldata.ValidDays = Convert.ToInt32(dr[5]);
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

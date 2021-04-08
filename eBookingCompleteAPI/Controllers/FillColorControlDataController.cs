using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillColorControlDataController : ApiController
    {
        // GET: GetControlData

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.Parametername + "</actionname><colorname>" + objbookingDetail.ParamValueStr + "</colorname>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.ID = Convert.ToInt32(dr[0]);
                    objcontroldata.Value = Convert.ToString(dr[1]);
                    objcontroldata.Flag = Convert.ToInt32(dr[2]);
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

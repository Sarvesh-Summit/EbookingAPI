using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillPremiaControlDataController : ApiController
    {
        // GET: GetControlData

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.Parametername + "</actionname><premianame>" + objbookingDetail.ParamValueStr + "</premianame>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<packageidlist>" + objbookingDetail.PackageID + "</packageidlist><isclassified>" + objbookingDetail.IsClassified + "</isclassified>"
                              + "<isdigital>" + objbookingDetail.IsDigital + "</isdigital></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.ID = Convert.ToInt32(dr[0]);
                    objcontroldata.Value = Convert.ToString(dr[1]);
                    objcontroldata.MinColumn = Convert.ToDouble(dr[2]);
                    objcontroldata.MaxColumn = Convert.ToDouble(dr[3]);
                    objcontroldata.MinHeight = Convert.ToDouble(dr[4]);
                    objcontroldata.MaxHeight = Convert.ToDouble(dr[5]);
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

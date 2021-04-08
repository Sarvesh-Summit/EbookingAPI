using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class MaterialPathController : ApiController
    {
        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>getfilepath</actionname>"
                                + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                               + "<logcentreid>" + objbookingDetail.RevenueCentreID + "</logcentreid>"
                               + "</ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                   
                    objcontroldata.ClassifiedMaterialPath = Convert.ToString(dr["ClassifiedMaterialPath"]);
                    objcontroldata.JobPath = Convert.ToString(dr["JobPath"]);
                    objcontroldata.ROFilePath = Convert.ToString(dr["ROFilePath"]);
                    objcontroldata.ClMatPath = Convert.ToString(dr["ClMatPath"]);
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

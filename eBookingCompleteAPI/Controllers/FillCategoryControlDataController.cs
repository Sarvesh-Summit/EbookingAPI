using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillCategoryControlDataController : ApiController
    {
        // GET: GetControlData

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.Parametername + "</actionname><adcatname>" + objbookingDetail.ParamValueStr + "</adcatname>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<adtypeid>" + objbookingDetail.AdtypeId + "</adtypeid><isclassified>" + objbookingDetail.IsClassified + "</isclassified></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.CategoryID = Convert.ToString(dr[0]);
                    objcontroldata.Value = Convert.ToString(dr[1]);
                    objcontroldata.IsLogoPossible = Convert.ToString(dr[2]);
                    objcontroldata.HeightLogo = Convert.ToString(dr[3]);
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

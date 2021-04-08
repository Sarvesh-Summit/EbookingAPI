using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillBoxChargesControlDataController : ApiController
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
                               + "<packagelist>" + objbookingDetail.PackageID + "</packagelist>"
                               + "<boxtypeid>" + objbookingDetail.BoxTypeID + "</boxtypeid>"
                               + "<adtypeid>" + objbookingDetail.AdtypeId + "</adtypeid>"
                               + "<ratecardid>"+ objbookingDetail.RateCardID + "</ratecardid>"
                               + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                               + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified></ebooking>";
                DataTable objdt = objHomeDAL.eBookingActions(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
                    objcontroldata.BoxChargePer = Convert.ToDouble(dr[1]);
                    objcontroldata.BoxChargeAmount = Convert.ToDouble(dr[0]);
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

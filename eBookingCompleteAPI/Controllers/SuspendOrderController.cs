using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class SuspendOrderController : ApiController
    {
        [HttpPost]
        public BookingDetail Post(BookingDetail objbookingDetail)
        {
            try
            {
                HomeDAL objHomeDAL = new HomeDAL();
                string strXml = string.Empty;
                strXml += "<ebooking><actionname>suspendorder</actionname><roid>" + objbookingDetail.ROID + "</roid>"
                       + "<orderlevel>" + objbookingDetail.OrderLevel + "</orderlevel>"
                       + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                       + "<isclassified>" + objbookingDetail.IsClassified + " </isclassified>"
                       + "<insnum>" + objbookingDetail.InsNum + "</insnum>"
                       + "<peid>" + objbookingDetail.PEID + "</peid>"
                       + "<releaseid>" + objbookingDetail.ReleaseID + "</releaseid>"
                       + "<uom>" + objbookingDetail.UOMID + "</uom>"
                       + "<reasonid>" + objbookingDetail.SuspendReasonID + "</reasonid>"
                       + "<reasonremark>" + objbookingDetail.SuspendRemarks + "</reasonremark>"
                       + "</ebooking>";


                DataTable objdt = objHomeDAL.eBookingActions(strXml).Tables[0];
                if (objdt.Rows.Count > 0)
                {
                    objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                    if (objbookingDetail.IsValid == 1)
                    {
                        objbookingDetail.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                        objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                    }
                    else
                    {
                        objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                        objbookingDetail.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ReportError("DisplayValidateAdController::Post:", ex);
            }
            return objbookingDetail;
        }
    }
}

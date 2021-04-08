using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetMyLogDetailsController : ApiController
    {

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public List<List<string>> Post(MyLogDetails objbookingDetail)
        {
            List<List<string>> listarray = new List<List<string>>();

            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.ParameterName + "</actionname>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified>"
                              + "<agencyid>" + objbookingDetail.AgencyId + "</agencyid>"
                              + "<roid>" + objbookingDetail.Roid + "</roid>"
                              + "<packageid>" + objbookingDetail.Packegid + "</packageid>"
                              + "<clientid>" + objbookingDetail.ClientId + "</clientid>"
                              + "<ronumber>" + objbookingDetail.RoNumber + "</ronumber>"
                              + "<canvassorid>" + objbookingDetail.CanvassorId + "</canvassorid>"
                              + "<dateflag>" + objbookingDetail.date + "</dateflag>"
                              + "<fromdate>" + objbookingDetail.DateFrom + "</fromdate>"
                              + "<todate>" + objbookingDetail.DateTo + "</todate></ebooking>";
                DataTable objdt = objHomeDAL.eBookingActions(strXml).Tables[0];
                List<String> columnlist = (from dc in objdt.Columns.Cast<DataColumn>()
                                           select dc.ColumnName).ToList();
                listarray.Add(columnlist);
                foreach (DataRow dr in objdt.Rows)
                    listarray.Add(dr.ItemArray.Select(o => o.ToString()).ToList());
            }
            catch (Exception ex)
            {
                Utility.ReportError("DisplayValidateAdController::Post:", ex);
            }
            return listarray;
        }


    }
}

using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class ClientDetailController : ApiController
    {
        [HttpPost]
        public List<List<string>> Post(BookingDetail objbookingDetail)
        {
            List<List<string>> listarray = new List<List<string>>();
            try
            {
                HomeDAL objHomeDAL = new HomeDAL();
                string strXml = string.Empty;
                strXml += "<ebooking><actionname>searchclient</actionname>"
                       + "<searchname>" + objbookingDetail.SearchClientName + "</searchname>"
                       + "<searchid>" + objbookingDetail.SearchClientID + "</searchid>"
                       + "<searchcity>" + objbookingDetail.SearchClientCity + "</searchcity>"
                       + "<searchaddress>" + objbookingDetail.SearchClientAddress + "</searchaddress>"
                       + "<searchcode>" + objbookingDetail.SearchClientOldCode + "</searchcode>"
                       + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified>"
                       + "</ebooking>";

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

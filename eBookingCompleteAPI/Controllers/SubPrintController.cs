using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class SubPrintController : ApiController
    {
        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public List<List<string>> Post(PrintData objbookingDetail)
        {
            List<List<string>> listarray = new List<List<string>>();

            try
            {
                string strXml = "Select * from VW_ClReceiptPrint_Payments where ReceiptID=" + objbookingDetail.ReceiptId + "";
                DataTable objdt = objHomeDAL.eBookingIsCheckprint(strXml).Tables[0];
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

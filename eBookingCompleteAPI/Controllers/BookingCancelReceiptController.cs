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
    public class BookingCancelReceiptController : ApiController
    {
        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IEnumerable<ControlData> Post(BookingDetail objbookingDetail)
        {
            List<ControlData> objListcontroldata = new List<ControlData>();
            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.Parametername + "</actionname>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                              + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified>"
                               + "<receiptid>" + objbookingDetail.ReceiptID + "</receiptid>"
                               + "<cancelreceiptdate>" + objbookingDetail.CancelReceiptDate + "</cancelreceiptdate>"
                               + "<cancelreceiptremarks>" + objbookingDetail.CancelReceiptRemark + "</cancelreceiptremarks></ebooking>";
                     
                DataTable objdt = objHomeDAL.eBookingActions(strXml).Tables[0];
                ControlData objcontroldata;
                foreach (DataRow dr in objdt.Rows)
                {
                    objcontroldata = new ControlData();
               
                    objcontroldata.Message = Convert.ToString(dr[1]);

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

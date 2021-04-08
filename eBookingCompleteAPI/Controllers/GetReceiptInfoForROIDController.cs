using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetReceiptInfoForROIDController : ApiController
    {

        // GET: GetControlData

        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public IDictionary<string, object> Post(BookingDetail objbookingDetail)
        {
            Dictionary<string, object> ReceiptInfoDetails = new Dictionary<string, object>();
            List<ReceiptInfo> objListReceiptInfo = new List<ReceiptInfo>();
            List<PendingROIDInfo> objListPendingROIDInfo = new List<PendingROIDInfo>();
            List<AdvanceReceiptInfo> objListAdvanceReceiptInfo = new List<AdvanceReceiptInfo>();

            try
            {
                string strXml = "<ebooking><actionname>" + objbookingDetail.Parametername + "</actionname>"
                              + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                               + "<roid>" + objbookingDetail.ROID + "</roid>"
                              + "<revenuecentreid>" + objbookingDetail.RevenueCentreID + "</revenuecentreid></ebooking>";
                DataSet objds = objHomeDAL.GeteBookingControlData(strXml);
                DataTable objdt = objds.Tables[0];
                DataTable objdt1 = objds.Tables[1];
                DataTable objdt2 = objds.Tables[2];

                ReceiptInfo objReceiptInfo;
                if (objdt.Rows.Count > 0)
                {
                    foreach (DataRow dr in objdt.Rows)
                    {
                        objReceiptInfo = new ReceiptInfo();
                        objReceiptInfo.AgencyID = Convert.ToString(dr["AgencyID"]);
                        objReceiptInfo.ClientID = Convert.ToString(dr["ClientID"]);
                        objReceiptInfo.ClientName = Convert.ToString(dr["ClientName"]);
                        objReceiptInfo.CasualAddress = Convert.ToString(dr["CasualAddress"]);
                        objReceiptInfo.City = Convert.ToString(dr["City"]);
                        objReceiptInfo.Zip = Convert.ToString(dr["zip"]);
                        objReceiptInfo.Phone = Convert.ToString(dr["Phone"]);
                        objReceiptInfo.AgencyName = Convert.ToString(dr["AgencyName"]);
                        objListReceiptInfo.Add(objReceiptInfo);
                    }
                }

                PendingROIDInfo objPendingROIDInfo;
                if (objdt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in objdt1.Rows)
                    {
                        objPendingROIDInfo = new PendingROIDInfo();
                        objPendingROIDInfo.ROID = Convert.ToString(dr["ROID"]);
                        objPendingROIDInfo.Net = Convert.ToString(dr["Net"]);
                        objListPendingROIDInfo.Add(objPendingROIDInfo);
                    }
                }

                AdvanceReceiptInfo objAdvanceReceiptInfo;
                if (objdt2.Rows.Count > 0)
                {
                    foreach (DataRow dr in objdt2.Rows)
                    {
                        objAdvanceReceiptInfo = new AdvanceReceiptInfo();
                        objAdvanceReceiptInfo.ReceiptID = Convert.ToString(dr["ReceiptID"]);
                        objAdvanceReceiptInfo.BalanceAmount = Convert.ToDouble(dr["BalanceAmount"]);
                        objListAdvanceReceiptInfo.Add(objAdvanceReceiptInfo);
                    }
                }

                ReceiptInfoDetails.Add("ReceiptInfo", objListReceiptInfo);
                ReceiptInfoDetails.Add("PendingROIDInfo", objListPendingROIDInfo);
                ReceiptInfoDetails.Add("AdvanceReceiptInfo", objListAdvanceReceiptInfo);
            }
            catch (Exception ex)
            {
            }
            return ReceiptInfoDetails;
        }

    }
}

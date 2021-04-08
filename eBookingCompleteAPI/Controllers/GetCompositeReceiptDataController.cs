using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetCompositeReceiptDataController : ApiController
    {

        public Dictionary<string, object> Post(BookingDetail objbookingDetail)
        {
            Dictionary<string, object> OrderDetails = new Dictionary<string, object>();
            List<OpenOrder> objListOpenOrder = new List<OpenOrder>();
            List<CompositeReceiptOrder> objListCompositeReceiptOrder = new List<CompositeReceiptOrder>();
            List<CompositeReceiptROID> objListCompositeReceiptROID = new List<CompositeReceiptROID>();
            OpenOrder objOpenOder;

            try
            {
                HomeDAL objHomeDAL = new HomeDAL();
                string strXml = string.Empty;
                strXml += "<ebooking><actionname>opencompositereceipt</actionname><receiptid>" + objbookingDetail.ReceiptID + "</receiptid></ebooking>";
                DataSet objds = objHomeDAL.eBookingActions(strXml);

                if (objds.Tables.Count == 1)
                {
                    objOpenOder = new OpenOrder();
                    objOpenOder.IsValid = Convert.ToInt16(objds.Tables[0].Rows[0]["ErrorFlag"]);
                    if (objOpenOder.IsValid == 1)
                    {
                        objOpenOder.ErrorMessage = Convert.ToString(objds.Tables[0].Rows[0]["ErrorMessage"]);
                        objOpenOder.IsValid = Convert.ToInt16(objds.Tables[0].Rows[0]["ErrorFlag"]);
                        objListOpenOrder.Add(objOpenOder);
                        OrderDetails.Add("OpenOrder", objListOpenOrder);
                    }
                }

                else
                {
                    DataTable objdt = objds.Tables[0];
                    DataTable objdt1 = objds.Tables[1];
                    CompositeReceiptOrder objCompositeReceiptOder;

                    if (objdt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in objdt.Rows)
                        {
                            objCompositeReceiptOder = new CompositeReceiptOrder();
                            objCompositeReceiptOder.ReceiptID = Convert.ToInt64(dr["ReceiptID"]);
                            objCompositeReceiptOder.TotalPayableAmount = Convert.ToDouble(dr["TotalPayableAmount"]);
                            objCompositeReceiptOder.TotalAmountPaid = Convert.ToDouble(dr["TotalAmountPaid"]);
                            objCompositeReceiptOder.WriteOffAmount = Convert.ToDouble(dr["WriteOffAmount"]);
                            objCompositeReceiptOder.LogUserID = Convert.ToInt64(dr["LogUserID"]);
                            objCompositeReceiptOder.ReceiptStatus = Convert.ToInt16(dr["ReceiptStatus"]);
                            objCompositeReceiptOder.ReceiptRemarks = Convert.ToString(dr["ReceiptRemarks"]);
                            objCompositeReceiptOder.CancelDate = Convert.ToString(dr["CancelDate"]);
                            objCompositeReceiptOder.BillingRemarks = Convert.ToString(dr["BillingRemarks"]);
                            objCompositeReceiptOder.CancellationRemarks = Convert.ToString(dr["CancellationRemarks"]);
                            objCompositeReceiptOder.ReceiptDate = Convert.ToString(dr["ReceiptDate"]);
                            objCompositeReceiptOder.AdvancedUsed = Convert.ToDouble(dr["AdvancedUsed"]);
                            objCompositeReceiptOder.AdvancedRecieved = Convert.ToDouble(dr["AdvancedRecieved"]);
                            objCompositeReceiptOder.ReceiptCentreID = Convert.ToInt16(dr["ReceiptCentreID"]);
                            objCompositeReceiptOder.ReceiptNumber = Convert.ToInt64(dr["ReceiptNumber"]);
                            objCompositeReceiptOder.IsClassified = Convert.ToInt16(dr["IsClassified"]);
                            objCompositeReceiptOder.CancelledUserId = Convert.ToInt16(dr["CancelledUserId"]);
                            objCompositeReceiptOder.AgencyID = Convert.ToInt16(dr["AgencyID"]);
                            objCompositeReceiptOder.ClientID = Convert.ToInt16(dr["ClientID"]);
                            objCompositeReceiptOder.CasualClient = Convert.ToString(dr["CasualClient"]);
                            objCompositeReceiptOder.AgencyName = Convert.ToString(dr["AgencyName"]);
                            objCompositeReceiptOder.BillTo = Convert.ToInt16(dr["BillTo"]);
                            objCompositeReceiptOder.RevenueCentreid = Convert.ToInt16(dr["RevenueCentreid"]);
                            objCompositeReceiptOder.MachineName = Convert.ToString(dr["MachineName"]);
                            objCompositeReceiptOder.CasualAddress = Convert.ToString(dr["CasualAddress"]);
                            objCompositeReceiptOder.City = Convert.ToString(dr["City"]);
                            objCompositeReceiptOder.Phone = Convert.ToString(dr["Phone"]);
                            objCompositeReceiptOder.Zip = Convert.ToString(dr["Zip"]);
                            objCompositeReceiptOder.ReceiptPaymentMode = Convert.ToInt16(dr["PaymentMode"]);
                            objCompositeReceiptOder.BankID = Convert.ToInt16(dr["BankID"]);
                            objCompositeReceiptOder.CheckNumber = Convert.ToString(dr["Number"]);
                            objCompositeReceiptOder.PaymentDate = Convert.ToString(dr["PaymentDate"]);
                            objCompositeReceiptOder.Amount = Convert.ToDouble(dr["Amount"]);
                            objCompositeReceiptOder.BankName = Convert.ToString(dr["BankName"]);
                            objCompositeReceiptOder.BranchName = Convert.ToString(dr["BranchName"]);
                            objCompositeReceiptOder.BranchID = Convert.ToInt16(dr["BranchID"]);
                            objCompositeReceiptOder.BankBranchCode = Convert.ToString(dr["BankBranchCode"]);
                            objCompositeReceiptOder.CashReceived = Convert.ToDouble(dr["CashReceived"]);
                            objCompositeReceiptOder.CashRefund = Convert.ToDouble(dr["CashRefund"]);
                            objCompositeReceiptOder.AdvanceReceiptID = Convert.ToInt64(dr["AdvanceReceiptID"]);
                            objListCompositeReceiptOrder.Add(objCompositeReceiptOder);
                        }
                    }

                    CompositeReceiptROID objCompositeReceiptROID;
                    if (objdt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr in objdt1.Rows)
                        {
                            objCompositeReceiptROID = new CompositeReceiptROID();
                            objCompositeReceiptROID.ROID = Convert.ToString(dr["ROID"]);
                            objCompositeReceiptROID.Net = Convert.ToDouble(dr["Net"]);
                            objListCompositeReceiptROID.Add(objCompositeReceiptROID);
                        }

                    }
                    OrderDetails.Add("CompoReceiptOrder", objListCompositeReceiptOrder);
                    OrderDetails.Add("CompoReceiptROID", objListCompositeReceiptROID);
                }
            }
            catch (Exception ex)
            {
                Utility.ReportError("DisplayOpenOrderController::Post:", ex);
            }
            return OrderDetails;
        }

    }
}

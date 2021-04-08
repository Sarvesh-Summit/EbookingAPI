using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Data;
using System.Web.Http;
namespace eBookingCompleteAPI.Controllers
{
    public class SaveNewReceiptDataController : ApiController
    {

        [HttpPost]
        public BookingDetail Post(BookingDetail objbookingDetail)
        {
            string strXml = string.Empty;
            try
            {
                HomeDAL objHomeDAL = new HomeDAL();
                string roids = objbookingDetail.PendingROID;
                string[] selectedroids = roids.Split(',');

                strXml += "<ebooking><orderlevel><receiptetail>"
                        + "<agencyid>" + objbookingDetail.AgencyID + "</agencyid><clientid>" + objbookingDetail.ClientID + "</clientid>"
                        + "<casualclientname>" + objbookingDetail.CasualClientName + "</casualclientname><casualaddress>" + objbookingDetail.CasualClientAddress + "</casualaddress>"
                        + "<City>" + objbookingDetail.CasualClientCity + "</City><Phone>" + objbookingDetail.CasualClientPhoneNo + "</Phone><Zip>" + objbookingDetail.CasualClientZipCode + "</Zip>"
                        + "<revenuecentreid>" + objbookingDetail.RevenueCentreID + "</revenuecentreid><loguserid>" + objbookingDetail.UserId + "</loguserid>"
                        + "<totalamountreceivable>" + objbookingDetail.ReceivableAmount + "</totalamountreceivable>"
                        + "<receiptamount>" + objbookingDetail.TotalReceivable + "</receiptamount>"
                        + "<writeoffamount>" + objbookingDetail.WriteoffAmount + "</writeoffamount>"
                        + "<totalamountpaid>" + objbookingDetail.ReceiptAmount + "</totalamountpaid>"
                        + "<receiptdate>" + DateTime.Now.ToString("dd/MM/yyyy") + "</receiptdate>"
                        + "<saveflag>" + objbookingDetail.SaveFlag + "</saveflag>"
                        + "<receiptremarks></receiptremarks>";
                for (var i = 0; i < selectedroids.Length; i++)
                {
                    strXml += "<OrdersPaid>"
                        + "<ROID>" + selectedroids[i] + "</ROID>"
                        + "</OrdersPaid>";
                }
                if (objbookingDetail.Amount != 0)
                {
                    strXml += "<paymentdetail>"
                        + "<paymentmodeid>" + objbookingDetail.PaymentModeID + "</paymentmodeid><chequenumber>" + objbookingDetail.ChequeNumber + "</chequenumber><chequedate></chequedate>"
                        + "<amount>" + objbookingDetail.Amount + "</amount><bankid>" + objbookingDetail.BankID + "</bankid><bankname>" + objbookingDetail.BranchBankName + "</bankname>"
                        + "<branchid>" + objbookingDetail.BankNameID + "</branchid><branchname>" + objbookingDetail.BranchName + "</branchname>"
                        + "<bankbranchcode>" + objbookingDetail.BankName + "</bankbranchcode>"
                        + "<advanceamount>" + objbookingDetail.AdvanceAmount + "</advanceamount><advancereceiptid>" + objbookingDetail.AdvanceReceiptID + "</advancereceiptid>"
                        + "<advanceutilised>" + objbookingDetail.AdvanceUtilised + "</advanceutilised>"
                        + "</paymentdetail>";
                }
                if (objbookingDetail.Amount1 != 0)
                {
                    strXml += "<paymentdetail>"
                        + "<paymentmodeid>" + objbookingDetail.PaymentModeID1 + "</paymentmodeid><chequenumber>" + objbookingDetail.ChequeNumber1 + "</chequenumber><chequedate></chequedate>"
                        + "<amount>" + objbookingDetail.Amount1 + "</amount><bankid>" + objbookingDetail.BankID1 + "</bankid><bankname>" + objbookingDetail.BranchBankName1 + "</bankname>"
                        + "<branchid>" + objbookingDetail.BankNameID1 + "</branchid><branchname>" + objbookingDetail.BranchName1 + "</branchname>"
                        + "<bankbranchcode>" + objbookingDetail.BankName1 + "</bankbranchcode>"
                        + "<advanceamount>" + objbookingDetail.AdvanceAmount1 + "</advanceamount><advancereceiptid>" + objbookingDetail.AdvanceReceiptID1 + "</advancereceiptid>"
                        + "<advanceutilised>" + objbookingDetail.AdvanceUtilised1 + "</advanceutilised>"
                        + "</paymentdetail>";
                }
                if (objbookingDetail.Amount2 != 0)
                {
                    strXml += "<paymentdetail>"
                        + "<paymentmodeid>" + objbookingDetail.PaymentModeID2 + "</paymentmodeid><chequenumber>" + objbookingDetail.ChequeNumber2 + "</chequenumber><chequedate></chequedate>"
                        + "<amount>" + objbookingDetail.Amount2 + "</amount><bankid>" + objbookingDetail.BankID2 + "</bankid><bankname>" + objbookingDetail.BranchBankName2 + "</bankname>"
                        + "<branchid>" + objbookingDetail.BankNameID2 + "</branchid><branchname>" + objbookingDetail.BranchName2 + "</branchname>"
                        + "<bankbranchcode>" + objbookingDetail.BankName2 + "</bankbranchcode>"
                        + "<advanceamount>" + objbookingDetail.AdvanceAmount2 + "</advanceamount><advancereceiptid>" + objbookingDetail.AdvanceReceiptID2 + "</advancereceiptid>"
                        + "<advanceutilised>" + objbookingDetail.AdvanceUtilised2 + "</advanceutilised>"
                        + "</paymentdetail>";
                }
                strXml += "</receiptetail></orderlevel></ebooking>";

                DataTable objdt = objHomeDAL.BookNewReceiptXML(strXml).Tables[0];

                if (objdt.Rows.Count > 0)
                {
                    objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                    if (objbookingDetail.IsValid > 0)
                    {
                        objbookingDetail.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                        objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                    }
                    else
                    {
                        objbookingDetail.ReceiptID = Convert.ToInt64(objdt.Rows[0]["ReceiptID"]);
                        objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                        objbookingDetail.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ReportLogError("SP_Name::EBK_SP_CreateReceiptXML:", ex, strXml);
            }
            return objbookingDetail;

        }

    }
}

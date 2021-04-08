using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetBookingIDDataController : ApiController
    {

        public Dictionary<string, object> Post(BookingDetail objbookingDetail)
        {
            Dictionary<string, object> OrderDetails = new Dictionary<string, object>();
            List<OpenOrder> objListOpenOrder = new List<OpenOrder>();
            List<ReceiptOrder> objListReceiptOrder = new List<ReceiptOrder>();
            List<ROFilesOrder> objListROFilesOrder = new List<ROFilesOrder>();
            OpenOrder objOpenOder;
            try
            {
                HomeDAL objHomeDAL = new HomeDAL();
                string strXml = string.Empty;
                strXml += "<ebooking><actionname>openbookingid</actionname><bookingid>" + objbookingDetail.BookingID + "</bookingid>"
                       + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                       + "<logcentreid>" + objbookingDetail.RevenueCentreID + "</logcentreid>"
                       + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified>"
                       + "<isdigital>" + objbookingDetail.IsDigital + "</isdigital></ebooking>";
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
                    DataTable objdt2 = objds.Tables[2];


                    if (objdt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in objdt.Rows)
                        {
                            objOpenOder = new OpenOrder();

                            objOpenOder.StartCol = Convert.ToString(dr["StartCol"]);
                            objOpenOder.Yposition = Convert.ToString(dr["Yposition"]);
                            objOpenOder.BoxNumber = Convert.ToString(dr["BoxNumber"]);
                            objOpenOder.RevenueCentreID = Convert.ToInt16(dr["RevenueCentreID"]);
                            objOpenOder.BookingCentreID = Convert.ToInt16(dr["BookingCentreID"]);
                            objOpenOder.IsClassified = Convert.ToInt16(dr["IsClassified"]);
                            objOpenOder.RODate = Convert.ToDateTime(dr["RODate"]).ToString("dd/MM/yyyy");
                            objOpenOder.BookingDate = Convert.ToDateTime(dr["BookingDate"]).ToString("dd/MM/yyyy HH:mm:ss.fff");
                            objOpenOder.BookingExecID = Convert.ToInt16(dr["BookingExecID"]);
                            objOpenOder.BookingNumber = Convert.ToString(dr["BookingNumber"]);
                            objOpenOder.RONumber = Convert.ToString(dr["RONumber"]);
                            objOpenOder.AgencyID = Convert.ToInt16(dr["AgencyID"]);
                            objOpenOder.ClientID = Convert.ToInt16(dr["ClientID"]);
                            objOpenOder.AgentID = Convert.ToInt16(dr["AgentID"]);
                            objOpenOder.CanvassorID = Convert.ToInt16(dr["CanvassorID"]);
                            objOpenOder.ROType = Convert.ToInt16(dr["ROType"]);
                            objOpenOder.BillingCycle = Convert.ToInt16(dr["BillingCycle"]);
                            objOpenOder.BillTo = Convert.ToInt16(dr["BillTo"]);
                            objOpenOder.BillType = Convert.ToInt16(dr["BillType"]);
                            objOpenOder.PaymentModeID = Convert.ToInt16(dr["PaymentMode"]);
                            objOpenOder.IsManualBilling = Convert.ToInt16(dr["IsManualBilling"]);
                            objOpenOder.SourceOrder = Convert.ToInt16(dr["SourceOrder"]);
                            objOpenOder.ROStatus = Convert.ToInt16(dr["ROStatus"]);
                            objOpenOder.RateFieldChanged = Convert.ToInt16(dr["RateFieldChanged"]);
                            objOpenOder.ProductID = Convert.ToInt16(dr["ProductID"]);
                            objOpenOder.BrandID = Convert.ToInt16(dr["BrandID"]);
                            objOpenOder.SMEID = Convert.ToInt16(dr["SMEID"]);
                            objOpenOder.BoxTypeID = Convert.ToInt16(dr["BoxTypeID"]);
                            objOpenOder.ROID = Convert.ToInt64(dr["ROID"]);
                            objOpenOder.BookingID = Convert.ToInt64(dr["BookingID"]);
                            objOpenOder.InsNum = Convert.ToInt16(dr["InsNum"]);
                            objOpenOder.PEID = Convert.ToInt16(dr["PEID"]);
                            objOpenOder.ReleaseID = Convert.ToInt16(dr["ReleaseID"]);
                            objOpenOder.ProdPEID = Convert.ToInt16(dr["ProdPEID"]);
                            objOpenOder.ProdReleaseID = Convert.ToInt16(dr["ProdReleaseID"]);
                            objOpenOder.ScheduledDate = Convert.ToDateTime(dr["ScheduledDate"]).ToString("dd/MM/yyyy");
                            objOpenOder.PackageID = Convert.ToInt16(dr["PackageID"]);
                            objOpenOder.AdTypeID = Convert.ToInt16(dr["AdTypeID"]);
                            objOpenOder.PremiaID = Convert.ToInt16(dr["PremiaID"]);
                            objOpenOder.ColorID = Convert.ToInt16(dr["Color"]);
                            objOpenOder.Status = Convert.ToInt16(dr["Status"]);
                            objOpenOder.AuditStatus = Convert.ToInt16(dr["AuditStatus"]);
                            objOpenOder.Free_or_Paid = Convert.ToInt16(dr["Free_or_Paid"]);
                            objOpenOder.FreeAds = Convert.ToInt16(dr["FreeAds"]);
                            objOpenOder.PaidAds = Convert.ToInt16(dr["PaidAds"]);
                            objOpenOder.ItemRateFieldChanged = Convert.ToInt16(dr["ItemRateFieldChanged"]);
                            objOpenOder.RateCardID = Convert.ToInt16(dr["RateCardID"]);
                            objOpenOder.AdRateID = Convert.ToInt16(dr["AdRateID"]);
                            objOpenOder.CardRate = Convert.ToDouble(dr["CardRate"]);
                            objOpenOder.CardAmount = Convert.ToDouble(dr["CardAmount"]);
                            objOpenOder.AgreedRate = Convert.ToDouble(dr["AgreedRate"]);
                            objOpenOder.AgreedAmount = Convert.ToDouble(dr["AgreedAmount"]);
                            objOpenOder.PECardBaseRate = Convert.ToDouble(dr["PECardBaseRate"]);
                            objOpenOder.ColorRate = Convert.ToDouble(dr["PECardCOlourRate"]);
                            objOpenOder.PremiaRate = Convert.ToDouble(dr["PECardPremiaRate"]);
                            objOpenOder.AgreedDiscPer = Convert.ToDecimal(dr["AgreedDiscPer"]);
                            objOpenOder.AgreedDiscAmount = Convert.ToDouble(dr["AgreedDiscAmount"]);
                            objOpenOder.CommissionPer = Convert.ToDouble(dr["CommissionPer"]);
                            objOpenOder.CommissionAmount = Convert.ToDouble(dr["CommissionAmount"]);
                            objOpenOder.DisCountColorPer = Convert.ToDouble(dr["DisCountColorPer"]);
                            objOpenOder.DisCountPremiaPer = Convert.ToDouble(dr["DisCountPremiaPer"]);
                            // objOpenOder.ExtraDiscountforPE = Convert.ToDouble(dr["ExtraDiscountforPE"]);
                            objOpenOder.ExtraChargesForPE = Convert.ToDouble(dr["ExtraChargesForPE"]);
                            objOpenOder.ExtraChargesPer = Convert.ToDouble(dr["ExtraChargesPer"]);
                            objOpenOder.ExtraDiscPer = Convert.ToDouble(dr["ExtraDiscPer"]);
                            objOpenOder.ExtraDiscAmount = Convert.ToDouble(dr["ExtraDiscAmount"]);
                            objOpenOder.ExtraBoxChargesPer = Convert.ToDouble(dr["BoxChargesPer"]);
                            objOpenOder.ExtraBoxChargesAmount = Convert.ToDouble(dr["BoxChargesAmount"]);
                            objOpenOder.PreVATAmountforPE = Convert.ToDouble(dr["PreVATAmountforPE"]);
                            objOpenOder.NetAmountforPE = Convert.ToDouble(dr["NetAmountforPE"]);
                            objOpenOder.Net = Convert.ToDouble(dr["Net"]);
                            objOpenOder.Receivable = Convert.ToDouble(dr["Receivable"]);
                            objOpenOder.VatPer = Convert.ToDouble(dr["VatPer"]);
                            objOpenOder.VatAmount = Convert.ToDouble(dr["VatAmount"]);
                            objOpenOder.WTPer = Convert.ToDouble(dr["WTPer"]);
                            objOpenOder.WTAmount = Convert.ToDouble(dr["WTAmount"]);
                            objOpenOder.MaterialID = Convert.ToString(dr["MaterialID"]);
                            objOpenOder.AdsizeID = Convert.ToInt16(dr["AdsizeID"]);
                            objOpenOder.Adsize = Convert.ToString(dr["AdSize"]);
                            objOpenOder.AdSizeHeight = Convert.ToDouble(dr["AdHeight"]);
                            objOpenOder.AdSizeWidth = Convert.ToDouble(dr["AdColsize"]);
                            objOpenOder.BillableSize = Convert.ToString(dr["BillableSize"]);
                            objOpenOder.BillableColSize = Convert.ToDouble(dr["BillableColSize"]);
                            objOpenOder.BillableHeight = Convert.ToDouble(dr["BillableHeight"]);
                            objOpenOder.BillableArea = Convert.ToDouble(dr["BillableArea"]);
                            objOpenOder.UOM = Convert.ToInt16(dr["UOM"]);
                            objOpenOder.SchemeID = Convert.ToInt16(dr["SchemeID"]);
                            objOpenOder.SchemeDetailID = Convert.ToInt16(dr["SchemedetailID"]);
                            objOpenOder.MaterialSource = Convert.ToInt16(dr["MaterialSource"]);
                            objOpenOder.MaterialType = Convert.ToInt16(dr["MaterialType"]);
                            objOpenOder.MaterialStatus = Convert.ToInt16(dr["MaterialStatus"]);
                            objOpenOder.AgencyName = Convert.ToString(dr["AgencyName"]);
                            objOpenOder.ClientName = Convert.ToString(dr["ClientName"]);
                            objOpenOder.CasualClientName = Convert.ToString(dr["CasualClientName"]);
                            objOpenOder.CanvassorName = Convert.ToString(dr["CanvassorName"]);
                            objOpenOder.UserName = Convert.ToString(dr["UserName"]);
                            objOpenOder.CentreName = Convert.ToString(dr["CentreName"]);
                            objOpenOder.MaterialPath = Convert.ToString(dr["MaterialPath"]);
                            objOpenOder.JobPath = Convert.ToString(dr["JobPath"]);
                            objOpenOder.ROFilePath = Convert.ToString(dr["ROFilePath"]);
                            objOpenOder.PkgIDs = Convert.ToString(dr["PkgIDs"]);
                            objOpenOder.PremiaName = Convert.ToString(dr["PremiaName"]);
                            objOpenOder.SizeName = Convert.ToString(dr["SizeName"]);
                            objOpenOder.ColorName = Convert.ToString(dr["ColorName"]);
                            objOpenOder.CustomerTypeID = Convert.ToInt16(dr["CasualRegularFlag"]);
                            objOpenOder.SchedulingInstructions = Convert.ToString(dr["SchedulingInstructions"]);
                            objOpenOder.BillingInstruction = Convert.ToString(dr["BillingInstruction"]);
                            objOpenOder.ProdInstructions = Convert.ToString(dr["ProdInstructions"]);
                            objOpenOder.Caption = Convert.ToString(dr["Caption"]);
                            objOpenOder.CasualAddress = Convert.ToString(dr["CasualAddress"]);
                            objOpenOder.CityID = Convert.ToInt32(dr["CityID"]);
                            objOpenOder.Zip = Convert.ToString(dr["Zip"]);
                            objOpenOder.Phone = Convert.ToString(dr["Phone"]);
                            objOpenOder.NicNumber = Convert.ToString(dr["NICNumber"]);
                            objOpenOder.VatNumber = Convert.ToString(dr["VATNumber"]);
                            objOpenOder.MBodyCount = Convert.ToString(dr["MBodyCount"]);
                            objOpenOder.AdClassification = Convert.ToString(dr["AdClassification"]);
                            objOpenOder.AdtypeID1 = Convert.ToInt32(dr["Adtype1"]);
                            objOpenOder.AdtypeID2 = Convert.ToInt32(dr["Adtype2"]);
                            objOpenOder.AdtypeID3 = Convert.ToInt32(dr["Adtype3"]);
                            objOpenOder.AdtypeID4 = Convert.ToInt32(dr["Adtype4"]);
                            objOpenOder.AllowCasualClient = Convert.ToInt32(dr["AllowCasualClient"]);
                            objOpenOder.BoxAddress = Convert.ToString(dr["BoxAddress"]);
                            objOpenOder.IsCD = Convert.ToInt32(dr["IsCD"]);
                            objOpenOder.StyleSheetID = Convert.ToInt32(dr["StyleSheetID"]);
                            objOpenOder.IsLogo = Convert.ToInt32(dr["IsLogo"]);
                            objOpenOder.U_BodyText = Convert.ToString(dr["U_BodyText"]);
                            //objOpenOder.TotalWords = Convert.ToString(dr["BodyCount"]);
                            //objOpenOder.CharCount = Convert.ToString(dr["charcount"]);
                            objOpenOder.PECode = Convert.ToString(dr["PECode"]);
                            objOpenOder.AdStatus = Convert.ToString(dr["AdStatus"]);
                            objOpenOder.FileNames = Convert.ToString(dr["FileNames"]);
                            objOpenOder.ReasonForUnconfirmationID = Convert.ToString(dr["ReasonForUnconfirmationID"]);
                            objOpenOder.FileHeight = Convert.ToString(dr["FileHeight"]);
                            objOpenOder.ReadOnlyFlag = Convert.ToString(dr["ReadOnlyFlag"]);
                            objOpenOder.BlockB4ScheduledDate = Convert.ToDateTime(dr["BlockB4ScheduledDate"]).ToString("dd/MM/yyyy");
                            objOpenOder.AdColumns = Convert.ToString(dr["CDADColumns"]);
                            objOpenOder.MaterialTypeDescription = Convert.ToString(dr["MaterialTypeDescription"]);
                            objOpenOder.DeferredPayment = Convert.ToInt16(dr["DeferredPayment"]);
                            objOpenOder.AgencyPaymentMode = Convert.ToInt16(dr["AgencyPaymentMode"]);
                            objOpenOder.CompositeReceiptID = Convert.ToString(dr["CompositeReceiptID"]);
                            objOpenOder.IsVatChange = Convert.ToInt16(dr["IsVatChange"]);
                            objOpenOder.IsTaxChange = Convert.ToInt16(dr["IsWTChange"]);
                            objOpenOder.IsDigital = Convert.ToInt16(dr["isDigital"]);
                            objListOpenOrder.Add(objOpenOder);
                        }
                    }

                    ROFilesOrder objROFilesOrder;
                    if (objdt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr in objdt1.Rows)
                        {

                            objROFilesOrder = new ROFilesOrder();
                            objROFilesOrder.ROID = Convert.ToInt64(dr["ROID"]);
                            objROFilesOrder.ROFileName = Convert.ToString(dr["ROFileName"]);
                            objROFilesOrder.ROFileType = Convert.ToString(dr["ROFileType"]);
                            objROFilesOrder.ROFileTitle = Convert.ToString(dr["ROFileTitle"]);
                            objListROFilesOrder.Add(objROFilesOrder);
                        }
                    }

                    ReceiptOrder objReceiptOder;
                    if (objdt2.Rows.Count > 0)
                    {
                        foreach (DataRow dr in objdt2.Rows)
                        {
                            objReceiptOder = new ReceiptOrder();
                            objReceiptOder.ReceiptID = Convert.ToInt64(dr["ReceiptID"]);
                            objReceiptOder.ReceiptNumber = Convert.ToInt64(dr["ReceiptNumber"]);
                            objReceiptOder.ReceiptPaymentMode = Convert.ToInt16(dr["PaymentMode"]);
                            objReceiptOder.BankID = Convert.ToInt16(dr["BankID"]);
                            objReceiptOder.BranchID = Convert.ToInt16(dr["BranchID"]);
                            objReceiptOder.CheckNumber = Convert.ToString(dr["Number"]);
                            objReceiptOder.Amount = Convert.ToDouble(dr["Amount"]);
                            objReceiptOder.TotalAmountPaid = Convert.ToDouble(dr["TotalAmountPaid"]);
                            objReceiptOder.WriteOffAmount = Convert.ToDouble(dr["WriteOffAmount"]);
                            objReceiptOder.CashRefund = Convert.ToDouble(dr["CashRefund"]);
                            objReceiptOder.CashReceived = Convert.ToDouble(dr["CashReceived"]);
                            objListReceiptOrder.Add(objReceiptOder);
                        }
                    }
                    OrderDetails.Add("OpenOrder", objListOpenOrder);
                    OrderDetails.Add("ROFilesOrder", objListROFilesOrder);
                    OrderDetails.Add("ReceiptOrder", objListReceiptOrder);
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

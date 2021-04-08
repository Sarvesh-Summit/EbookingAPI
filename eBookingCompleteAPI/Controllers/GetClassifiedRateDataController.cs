using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetClassifiedRateDataController : ApiController
    {
        [HttpPost]
        public IEnumerable<CSRateCalculation> Post(BookingDetail objbookingDetail)
        {
            List<CSRateCalculation> objListRate = new List<CSRateCalculation>();
            try
            {
                HomeDAL objHomeDAL = new HomeDAL();
                string strXml = string.Empty;
                string dates = objbookingDetail.DateSelected;
                string[] selecteddate = dates.Split(',');
                string packages = objbookingDetail.PackageID;
                string[] selectedpackages = packages.Split(',');
                string peids = objbookingDetail.PEID;
                string[] selectedpeids = peids.Split(',');
                string packageids = string.Empty;
                string statusids = objbookingDetail.Status;
                string[] selectedstatusids = statusids.Split(',');
                string cauditstatusids = objbookingDetail.AuditStatus;
                string[] selectedcauditstatusids = cauditstatusids.Split(',');
                int totalrecordreturn = objbookingDetail.list.Count;
                if (selectedpackages.Length == 1)
                {
                    packageids = objbookingDetail.PackageID;
                }
                else
                {
                    packageids = "0";
                }

                if (selecteddate.Length > 0)
                {
                    strXml += "<ebooking>"
                           + "<orderlevel>"
                           + "<roid>" + objbookingDetail.ROID + "</roid>"
                           + "<bookingdate>" + objbookingDetail.BookingDate + "</bookingdate>"
                           + "<revenuecentreid>" + objbookingDetail.RevenueCentreID + "</revenuecentreid>"
                           + "<bookingcentreid>" + objbookingDetail.BookingCentreID + "</bookingcentreid>"
                           + "<ratecentreid>" + objbookingDetail.RevenueCentreID + "</ratecentreid>"
                           + "<bookingexecid>" + objbookingDetail.UserId + "</bookingexecid>"
                           + "<ronumber>" + objbookingDetail.RONumber + "</ronumber>"
                           + "<agencyid>" + objbookingDetail.AgencyID + "</agencyid>"
                           + "<clientid>" + objbookingDetail.ClientID + "</clientid>"
                           + "<ccname>" + objbookingDetail.ClientName + "</ccname>"
                           + "<ccvatnumber>" + objbookingDetail.ClientVatNum + "</ccvatnumber>"
                           //+ "<adflag>1</adflag>"
                           //+ "<rateflag>0</rateflag>"
                           + "<packageid>" + packageids + "</packageid>"
                           + "<packagelist>" + objbookingDetail.PackageID + "</packagelist>"
                           + "<productid>" + objbookingDetail.ProductID + "</productid>"
                           + "<totalinsertions>" + selecteddate.Length + "</totalinsertions>"
                           + "<uom>" + objbookingDetail.UOMID + "</uom>"
                           + "<isclassified>" + objbookingDetail.IsClassified + "</isclassified>"
                           + "<isdigital>" + objbookingDetail.IsDigital + "</isdigital>"
                           + "<ratefieldchanged>" + objbookingDetail.RateFieldChanged + "</ratefieldchanged>"
                           + "<boxtypeid>" + objbookingDetail.BoxTypeID + "</boxtypeid>"
                           + "<paymentmode>" + objbookingDetail.PaymentTypeID + "</paymentmode>"
                           + "<ismanualbilling>" + objbookingDetail.IsManualBilling + "</ismanualbilling>"
                           + "<isvatchange>" + objbookingDetail.IsVatChange + "</isvatchange>"
                           + "<iswtchange>" + objbookingDetail.IsTaxChange + "</iswtchange>"
                           + "<agencycommissionper>" + objbookingDetail.AgencyCommissionPer + "</agencycommissionper>"
                           + "<ratecardid>" + objbookingDetail.RateCardID + "</ratecardid>";

                    if (objbookingDetail.IsVatChange == 1)
                    {
                        strXml += "<modifyvatper>" + objbookingDetail.ModifyVatPer + "</modifyvatper>";
                    }
                    if (objbookingDetail.IsTaxChange == 1)
                    {
                        strXml += "<modifywtper>" + objbookingDetail.ModifyTaxPer + "</modifywtper>";
                    }

                    for (var i = 0; i < totalrecordreturn; i++)    //totalrecordreturn
                    {
                        var date = objbookingDetail.list[i].ScheduledDate.Substring(0, 10);
                        strXml += "<insertlevel>"
                                 + "<insnum>" + objbookingDetail.list[i].InsNum + "</insnum>"
                                 + "<invoicenum>0</invoicenum>";
                        var peid = objbookingDetail.list[i].PEID;
                        strXml += "<itemlevel>"
                                 + "<peid>" + peid + "</peid>"
                                 + "<status>" + objbookingDetail.list[i].Status + "</status>"
                                 + "<auditstatus>" + objbookingDetail.list[i].AuditStatus + "</auditstatus>"
                                 + "<paymentstatus>0</paymentstatus>"
                                 + "<materialstatus>0</materialstatus>"
                                 + "<adtypeid>" + objbookingDetail.AdtypeId + "</adtypeid>";
                        strXml += "<adtype1>" + objbookingDetail.list[i].AdtypeID1 + "</adtype1>"
                            + "<adtype2>" + objbookingDetail.list[i].AdtypeID2 + "</adtype2>"
                            + "<adtype3>" + objbookingDetail.list[i].AdtypeID3 + "</adtype3>"
                            + "<adtype4>" + objbookingDetail.list[i].AdtypeID4 + "</adtype4>"
                            + "<stylesheetid>" + objbookingDetail.list[i].StyleSheetID + "</stylesheetid>"
                            + "<materialid>" + objbookingDetail.list[i].MaterialID + "</materialid>";

                        strXml += "<iscd>" + objbookingDetail.IsCD + "</iscd>"
                             + "<islogo>" + objbookingDetail.IsLogo + "</islogo>";
                        if (objbookingDetail.IsCD == 0)
                        {
                            strXml += "<totalwords>" + objbookingDetail.list[i].TotalWords + "</totalwords>"
                         + "<mbodycount>" + objbookingDetail.list[i].MBodyCount + "</mbodycount>"
                         + "<charcount>" + objbookingDetail.list[i].CharCount + "</charcount>"
                         + "<bodytext>" + objbookingDetail.list[i].U_BodyText + "</bodytext>";
                        }
                        else
                        {
                            strXml += "<totalwords>" + objbookingDetail.TotalWords + "</totalwords>"
                         + "<mbodycount>" + objbookingDetail.MBodyCount + "</mbodycount>"
                         + "<charcount>" + objbookingDetail.CharCount + "</charcount>"
                         + "<bodytext>" + objbookingDetail.AdText + "</bodytext>";
                        }
                        strXml += "<releaseid>0</releaseid>"
                            + "<scheduleddate>" + date + "</scheduleddate>"
                            + "<adcolumns>" + objbookingDetail.ClassifiedCol + "</adcolumns>"
                            + "<fileheight>" + objbookingDetail.LogoHeight + "</fileheight>";

                        strXml += "<releaseid>0</releaseid>"
                             + "<scheduleddate>" + date + "</scheduleddate>"
                             + "<adcolumns>" + objbookingDetail.ClassifiedCol + "</adcolumns>"
                             + "<fileheight>" + objbookingDetail.LogoHeight + "</fileheight>";
                        if (objbookingDetail.IsCD == 0)
                        {
                            strXml += "<adsize>" + objbookingDetail.list[i].AdSizeHeight + "*" + objbookingDetail.AdsizeWidth + "</adsize>"
                         + "<adheight>" + objbookingDetail.list[i].AdSizeHeight + "</adheight>"
                         + "<adwidth>" + objbookingDetail.AdsizeWidth + "</adwidth>"
                         + "<adarea>" + Convert.ToDouble(objbookingDetail.list[i].AdSizeHeight) * Convert.ToDouble(objbookingDetail.AdsizeWidth) + "</adarea>"
                         + "<billablesize>" + objbookingDetail.list[i].AdSizeHeight + "*" + objbookingDetail.AdsizeWidth + "</billablesize>"
                         + "<billableheight>" + objbookingDetail.list[i].AdSizeHeight + "</billableheight>"
                         + "<billablewidth>" + objbookingDetail.AdsizeWidth + "</billablewidth>"
                         + "<billablearea>" + Convert.ToDouble(objbookingDetail.list[i].AdSizeHeight) * Convert.ToDouble(objbookingDetail.AdsizeWidth) + "</billablearea>";
                        }
                        else
                        {
                            strXml += "<adsize>" + objbookingDetail.AdsizeHeight + "*" + objbookingDetail.AdsizeWidth + "</adsize>"
                         + "<adheight>" + objbookingDetail.AdsizeHeight + "</adheight>"
                         + "<adwidth>" + objbookingDetail.AdsizeWidth + "</adwidth>"
                         + "<adarea>" + Convert.ToDouble(objbookingDetail.AdsizeHeight) * Convert.ToDouble(objbookingDetail.AdsizeWidth) + "</adarea>"
                         + "<billablesize>" + objbookingDetail.AdsizeHeight + "*" + objbookingDetail.AdsizeWidth + "</billablesize>"
                         + "<billableheight>" + objbookingDetail.AdsizeHeight + "</billableheight>"
                         + "<billablewidth>" + objbookingDetail.AdsizeWidth + "</billablewidth>"
                         + "<billablearea>" + Convert.ToDouble(objbookingDetail.AdsizeHeight) * Convert.ToDouble(objbookingDetail.AdsizeWidth) + "</billablearea>";
                        }
                        strXml += "<itemratefieldchanged>" + objbookingDetail.list[i].ItemRateFieldChanged + "</itemratefieldchanged>"
                             + "<agreedrate>" + objbookingDetail.list[i].AgreedRate + "</agreedrate>"
                             + "<agreedamount>" + objbookingDetail.list[i].AgreedAmount + "</agreedamount>"
                             + "<agreeddiscper>" + objbookingDetail.list[i].AgreedDiscPer + "</agreeddiscper>"
                             + "<extrachargesper>" + objbookingDetail.list[i].ExtraChargesPer + "</extrachargesper>"
                             + "<extrachargesamount>" + objbookingDetail.list[i].ExtraChargesAmount + "</extrachargesamount>"
                             + "<extradiscountper>" + objbookingDetail.list[i].ExtraDiscPer + "</extradiscountper>"
                             + "<extradiscountamount>" + objbookingDetail.list[i].ExtraDiscAmount + "</extradiscountamount>"
                             + "<extraboxchargesper>" + objbookingDetail.ExtraBoxChargesPer + "</extraboxchargesper>"
                             + "<extraboxchargesamount>" + objbookingDetail.ExtraBoxChargesAmount + "</extraboxchargesamount>"
                             + "<readonlyflag>" + objbookingDetail.list[i].ReadOnlyFlag + "</readonlyflag>"
                             + "<boxnumber>" + objbookingDetail.list[i].BoxNumber + "</boxnumber>"
                             + "<startcol>" + objbookingDetail.list[i].StartCol + "</startcol>"
                             + "<yposition>" + objbookingDetail.list[i].Yposition + "</yposition>"
                      + "</itemlevel>";
                        strXml += "</insertlevel>";
                    }

                    if (objbookingDetail.PaymentTypeID == 1)
                    {
                        strXml += "<receiptetail>"
                             + "<receiptamount>" + objbookingDetail.TotalReceivable + "</receiptamount>"
                             + "<totalamountpaid>" + objbookingDetail.ReceiptAmount + "</totalamountpaid>"
                             + "<writeoffamount>" + objbookingDetail.WriteoffAmount + "</writeoffamount>"
                             + "<receiptdate>" + DateTime.Now.ToString("dd/MM/yyyy") + "</receiptdate>";
                        if (objbookingDetail.Amount != 0)
                        {
                            strXml += "<paymentdetail>"
                                + "<paymentmodeid>" + objbookingDetail.PaymentModeID + "</paymentmodeid>"
                                + "<chequenumber>" + objbookingDetail.ChequeNumber + "</chequenumber>"
                                + "<chequedate></chequedate>"
                                + "<amount>" + objbookingDetail.Amount + "</amount>"
                                + "<bankid>" + objbookingDetail.BankID + "</bankid>"
                                + "<bankname>" + objbookingDetail.BranchBankName + "</bankname>"
                                + "<branchid>" + objbookingDetail.BankNameID + "</branchid>"
                                + "<branchname>" + objbookingDetail.BranchName + "</branchname>"
                                + "<bankbranchcode>" + objbookingDetail.BankName + "</bankbranchcode>"
                           + "</paymentdetail>";
                        }
                        if (objbookingDetail.Amount1 != 0)
                        {
                            strXml += "<paymentdetail>"
                             + "<paymentmodeid>" + objbookingDetail.PaymentModeID1 + "</paymentmodeid>"
                             + "<chequenumber>" + objbookingDetail.ChequeNumber1 + "</chequenumber>"
                             + "<chequedate></chequedate>"
                             + "<amount>" + objbookingDetail.Amount1 + "</amount>"
                             + "<bankid>" + objbookingDetail.BankID1 + "</bankid>"
                             + "<bankname>" + objbookingDetail.BranchBankName1 + "</bankname>"
                             + "<branchid>" + objbookingDetail.BankNameID1 + "</branchid>"
                             + "<branchname>" + objbookingDetail.BranchName1 + "</branchname>"
                             + "<bankbranchcode>" + objbookingDetail.BankName1 + "</bankbranchcode>"
                        + "</paymentdetail>";
                        }
                        if (objbookingDetail.Amount2 != 0)
                        {
                            strXml += "<paymentdetail>"
                             + "<paymentmodeid>" + objbookingDetail.PaymentModeID2 + "</paymentmodeid>"
                             + "<chequenumber>" + objbookingDetail.ChequeNumber2 + "</chequenumber>"
                             + "<chequedate></chequedate>"
                             + "<amount>" + objbookingDetail.Amount2 + "</amount>"
                             + "<bankid>" + objbookingDetail.BankID2 + "</bankid>"
                             + "<bankname>" + objbookingDetail.BranchBankName2 + "</bankname>"
                             + "<branchid>" + objbookingDetail.BankNameID2 + "</branchid>"
                             + "<branchname>" + objbookingDetail.BranchName2 + "</branchname>"
                             + "<bankbranchcode>" + objbookingDetail.BankName2 + "</bankbranchcode>"
                         + "</paymentdetail>";
                        }
                        strXml += "</receiptetail>";
                    }
                    strXml += "</orderlevel></ebooking>";
                }

                DataTable objdt = objHomeDAL.GeteBookingRateData(strXml).Tables[0];
                CSRateCalculation objRate;

                if (objdt.Rows.Count > 0)
                {
                    objRate = new CSRateCalculation();
                    objRate.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                    if (objRate.IsValid == 1 || objRate.IsValid == -2)
                    {
                        objRate.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                        objRate.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                        objListRate.Add(objRate);
                    }
                    else
                    {
                        foreach (DataRow dr in objdt.Rows)
                        {
                            objRate = new CSRateCalculation();
                            objRate.StartCol = Convert.ToString(dr["StartCol"]);
                            objRate.Yposition = Convert.ToString(dr["Yposition"]);
                            objRate.BoxNumber = Convert.ToString(dr["BoxNumber"]);
                            objRate.RecID = Convert.ToInt16(dr["RecID"]);
                            objRate.BaseRate = Convert.ToDouble(dr["BaseRate"]);
                            objRate.CardRate = Convert.ToDouble(dr["CardRate"]);
                            objRate.CardAmount = Convert.ToDouble(dr["CardAmount"]);
                            objRate.AgreedRate = Convert.ToDouble(dr["AgreedRate"]);
                            objRate.AgreedAmount = Convert.ToDouble(dr["AgreedAmount"]);
                            objRate.AgreedDiscPer = Convert.ToDouble(dr["AgreedDiscPer"]);
                            objRate.AgreedDiscAmount = Convert.ToDouble(dr["AgreedDiscAmount"]);
                            objRate.RateCardID = Convert.ToInt16(dr["RateCardID"]);
                            objRate.AdRateID = Convert.ToInt16(dr["AdRateID"]);
                            objRate.RateDiff = Convert.ToDouble(dr["RateDiff"]);
                            objRate.BillableArea = Convert.ToDouble(dr["BillableArea"]);
                            objRate.SizeID = Convert.ToInt16(dr["SizeID"]);
                            objRate.AdSizeWidth = Convert.ToDouble(dr["SizeWidth"]);
                            objRate.AdSizeHeight = Convert.ToDouble(dr["SizeHeight"]);
                            objRate.AdSizeArea = Convert.ToDouble(dr["SizeArea"]);
                            objRate.ColWidth = Convert.ToDouble(dr["ColWidth"]);
                            objRate.ColumnSize = Convert.ToDouble(dr["ColumnSize"]);
                            objRate.Gutter = Convert.ToDouble(dr["Gutter"]);
                            objRate.AgencyCommissionPer = Convert.ToDouble(dr["AgencyCommissionPer"]);
                            objRate.AgencyCommissionAmount = Convert.ToDouble(dr["AgencyCommissionAmount"]);
                            objRate.PreVATAmount = Convert.ToDouble(dr["PreVATAmount"]);
                            objRate.Receivable = Convert.ToDouble(dr["Receivable"]);
                            objRate.NetReceivable = Convert.ToDouble(dr["NetReceivable"]);
                            objRate.ColorRate = Convert.ToDouble(dr["ColorRate"]);
                            objRate.PremiaRate = Convert.ToDouble(dr["PremiaRate"]);
                            objRate.VATPer = Convert.ToDouble(dr["VATPer"]);
                            objRate.VATAmount = Convert.ToDouble(dr["VATAmount"]);
                            objRate.WtPer = Convert.ToDouble(dr["WtPer"]);
                            objRate.WTAmount = Convert.ToDouble(dr["WTAmount"]);
                            objRate.ExtraDiscPer = Convert.ToDouble(dr["ExtraDiscPer"]);
                            objRate.ExtraDiscAmount = Convert.ToDouble(dr["ExtraDiscAmount"]);
                            objRate.ExtraChargesPer = Convert.ToDouble(dr["ExtraChargesPer"]);
                            objRate.ExtraChargesAmount = Convert.ToDouble(dr["ExtraChargesAmount"]);
                            objRate.ExtraBoxChargesPer = Convert.ToDouble(dr["BoxChargesPer"]);
                            objRate.ExtraBoxChargesAmount = Convert.ToDouble(dr["BoxChargesAmount"]);
                            objRate.ScheduledDate = Convert.ToDateTime(dr["ScheduledDate"]).ToString("dd/MM/yyyy");
                            objRate.InsNum = Convert.ToInt16(dr["InsNum"]);
                            objRate.PackageID = Convert.ToInt16(dr["PackageID"]);
                            objRate.PublicationID = Convert.ToInt16(dr["PublicationID"]);
                            objRate.PEID = Convert.ToInt16(dr["PEID"]);
                            objRate.PremiaID = Convert.ToInt16(dr["PremiaID"]);
                            objRate.ColorID = Convert.ToInt16(dr["ColorID"]);
                            objRate.SchemeID = Convert.ToInt16(dr["SchemeID"]);
                            objRate.SchemeDetailID = Convert.ToInt16(dr["SchemeDetailID"]);
                            objRate.SchemeAmount = Convert.ToDouble(dr["SchemeAmount"]);
                            objRate.SchemeName = Convert.ToString(dr["SchemeName"]);
                            objRate.SchemeDays = Convert.ToString(dr["SchemeDays"]);
                            objRate.AdTypeID = Convert.ToInt16(dr["AdTypeID"]);
                            objRate.StyleSheetID = Convert.ToInt16(dr["StyleSheetID"]);
                            objRate.StyleSheetName = Convert.ToString(dr["StyleSheetName"]);
                            objRate.MinAmount = Convert.ToDouble(dr["MinAmount"]);
                            objRate.MinArea = Convert.ToDouble(dr["MinArea"]);
                            objRate.UOM = Convert.ToInt16(dr["UOM"]);
                            objRate.Status = Convert.ToInt16(dr["Status"]);
                            objRate.AuditStatus = Convert.ToInt16(dr["AuditStatus"]);
                            objRate.MaterialType = Convert.ToInt16(dr["MaterialType"]);
                            objRate.MaterialSource = Convert.ToInt16(dr["MaterialSource"]);
                            objRate.ReceiptPayTypeID = Convert.ToInt16(dr["ReceiptPayTypeID"]);
                            objRate.MBodyCount = Convert.ToString(dr["MBodyCount"]);
                            objRate.RateFieldChanged = Convert.ToInt16(dr["RateFieldChanged"]);
                            objRate.PECode = Convert.ToString(dr["PECode"]);
                            objRate.AdStatus = Convert.ToString(dr["AdStatus"]);
                            objRate.AdClassification = Convert.ToString(dr["AdClassification"]);
                            objRate.AdtypeID1 = Convert.ToInt16(dr["Adtype1"]);
                            objRate.AdtypeID2 = Convert.ToInt16(dr["Adtype2"]);
                            objRate.AdtypeID3 = Convert.ToInt16(dr["Adtype3"]);
                            objRate.AdtypeID4 = Convert.ToInt16(dr["Adtype4"]);
                            objRate.MaterialID = Convert.ToString(dr["MaterialID"]);
                            objRate.ReadOnlyFlag = Convert.ToString(dr["ReadOnlyFlag"]);
                            objRate.AdColumns = Convert.ToString(dr["AdColumns"]);
                            objRate.ItemRateFieldChanged = Convert.ToInt16(dr["ItemRateFieldChanged"]);
                            objRate.PackageIDSent = Convert.ToInt16(dr["PackageIDSent"]);
                            objRate.U_BodyText = Convert.ToString(dr["bodytext"]);
                            objRate.TotalWords = Convert.ToString(dr["totalwords"]);
                            objRate.CharCount = Convert.ToString(dr["charcount"]);
                            objListRate.Add(objRate);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ReportError("DisplayRateCalculationController::Post:", ex);
            }
            return objListRate;
        }
    }
}

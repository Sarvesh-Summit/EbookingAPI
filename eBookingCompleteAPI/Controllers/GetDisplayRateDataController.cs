using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class GetDisplayRateDataController : ApiController
    {
        [HttpPost]
        public IEnumerable<DSRateCalculation> Post(BookingDetail objbookingDetail)
        {
            List<DSRateCalculation> objListRate = new List<DSRateCalculation>();
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
                           + "<bookingdate>" + objbookingDetail.BookingDate + "</bookingdate>" // + "<bookingdate>" + DateTime.Now.ToString("dd/MM/yyyy") + "</bookingdate>"
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
                           +"<ratecardid>" + objbookingDetail.RateCardID + "</ratecardid>";

                    if (objbookingDetail.IsVatChange == 1)
                    {
                        strXml += "<modifyvatper>" + objbookingDetail.ModifyVatPer + "</modifyvatper>";
                    }
                    if (objbookingDetail.IsTaxChange == 1)
                    {
                        strXml += "<modifywtper>" + objbookingDetail.ModifyTaxPer + "</modifywtper>";
                    }

                    for (var i = 0; i < objbookingDetail.list.Count; i++)
                    {
                       // var date = selecteddate[i];
                        var date = objbookingDetail.list[i].ScheduledDate.Substring(0, 10);
                        strXml += "<insertlevel>"
                                 + "<insnum>" + objbookingDetail.list[i].InsNum + "</insnum>" //+ "<insnum>" + (i + 1) + "</insnum>"
                                 + "<invoicenum>0</invoicenum>";
                        //for (var j = 0; j < selectedpeids.Length; j++)
                        //{
                            var peid = objbookingDetail.list[i].PEID;//selectedpeids[j];
                            strXml += "<itemlevel>"
                                 + "<peid>" + peid + "</peid>"
                                 + "<adtypeid>" + objbookingDetail.AdtypeId + "</adtypeid>"
                                 + "<releaseid>0</releaseid>"
                                 + "<scheduleddate>" + date + "</scheduleddate>"
                                 + "<status>"+ objbookingDetail.list[i].Status + "</status>"
                                 + "<auditstatus>" + objbookingDetail.list[i].AuditStatus + "</auditstatus>"
                                 + "<paymentstatus>0</paymentstatus>"
                                 + "<materialstatus>0</materialstatus>"
                                 + "<adsize>" + objbookingDetail.list[i].AdSizeHeight + "*" + objbookingDetail.list[i].AdSizeWidth + "</adsize>"
                                 + "<adsizeid>" + objbookingDetail.list[i].AdsizeID + "</adsizeid>"
                                 + "<adheight>" + objbookingDetail.list[i].AdSizeHeight + "</adheight>"
                                 + "<adwidth>" + objbookingDetail.list[i].AdSizeWidth + "</adwidth>"
                                 + "<adarea>" + Convert.ToDouble(objbookingDetail.list[i].AdSizeHeight) * Convert.ToDouble(objbookingDetail.list[i].AdSizeWidth) + "</adarea>"
                                 + "<billablesize>" + objbookingDetail.list[i].BillableSize + "</billablesize>"
                                 + "<billableheight>" + objbookingDetail.list[i].BillableSize.Split('*')[0] + "</billableheight>"
                                 + "<billablewidth>" + objbookingDetail.list[i].BillableSize.Split('*')[1] + "</billablewidth>"
                                 + "<billablearea>" + Convert.ToDouble(objbookingDetail.list[i].BillableSize.Split('*')[0]) * Convert.ToDouble(objbookingDetail.list[i].BillableSize.Split('*')[1]) + "</billablearea>"
                                 //+ "<billablesize>" + objbookingDetail.list[i].BillableSize + "</billablesize>"
                                 //+ "<billableheight>" + objbookingDetail.list[i].Billableheight + "</billableheight>"
                                 //+ "<billablewidth>" + objbookingDetail.list[i].Billablewidth + "</billablewidth>"
                                 //+ "<billablearea>" + Convert.ToDouble(objbookingDetail.list[i].Billableheight) * Convert.ToDouble(objbookingDetail.list[i].Billablewidth) + "</billablearea>"
                                 + "<premiaid>" + objbookingDetail.list[i].PremiaID + "</premiaid>"
                                 + "<colorid>" + objbookingDetail.list[i].ColorID + "</colorid>"
                                 + "<itemratefieldchanged>" + objbookingDetail.list[i].ItemRateFieldChanged + "</itemratefieldchanged>"
                                 + "<agreedrate>" + objbookingDetail.list[i].AgreedRate + "</agreedrate>"
                                 + "<agreedamount>" + objbookingDetail.list[i].AgreedAmount + "</agreedamount>"
                                 + "<agreeddiscper>" + objbookingDetail.list[i].AgreedDiscPer + "</agreeddiscper>"
                                 + "<extrachargesper>" + objbookingDetail.list[i].ExtraChargesPer + "</extrachargesper>"
                                 + "<extrachargesamount>" + objbookingDetail.list[i].ExtraChargesAmount + "</extrachargesamount>"
                                 + "<extradiscountper>" + objbookingDetail.list[i].ExtraDiscPer + "</extradiscountper>"
                                 + "<extradiscountamount>" + objbookingDetail.list[i].ExtraDiscAmount + "</extradiscountamount>"
                                 + "<extraboxchargesper>" + objbookingDetail.ExtraBoxChargesPer + "</extraboxchargesper>"
                                 + "<extraboxchargesamount>" + objbookingDetail.ExtraBoxChargesAmount + "</extraboxchargesamount>"
                                 + "<materialtype>" + objbookingDetail.list[i].MaterialType + "</materialtype>"
                                 + "<materialid>" + objbookingDetail.list[i].MaterialID + "</materialid>"
                                 + "<readonlyflag>" + objbookingDetail.list[i].ReadOnlyFlag + "</readonlyflag>"
                                 + "<boxnumber>" + objbookingDetail.list[i].BoxNumber + "</boxnumber>"
                                 + "<startcol>" + objbookingDetail.list[i].StartCol + "</startcol>"
                                 + "<yposition>" + objbookingDetail.list[i].Yposition + "</yposition>"
                          + "</itemlevel>";
                      //  }
                        strXml += "</insertlevel>";
                    }
                    strXml += "</orderlevel></ebooking>";
                }

                 DataTable objdt = objHomeDAL.GeteBookingRateData(strXml).Tables[0];
                DSRateCalculation objRate;

                if (objdt.Rows.Count > 0)
                {
                    objRate = new DSRateCalculation();
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
                            objRate = new DSRateCalculation();
                            objRate.StartCol = Convert.ToString(dr["StartCol"]);
                            objRate.Yposition = Convert.ToString(dr["Yposition"]);
                            objRate.BoxNumber = Convert.ToString(dr["BoxNumber"]);
                            objRate.RecID = Convert.ToInt16(dr["RecID"]);
                            objRate.BaseRate = Convert.ToDouble(dr["BaseRate"]);
                            objRate.CardRate = Convert.ToDouble(dr["CardRate"]);
                            objRate.CardAmount = Convert.ToDouble(dr["CardAmount"]);
                            objRate.AgreedRate = Convert.ToDouble(dr["AgreedRate"]);
                            objRate.AgreedAmount = Convert.ToDouble(dr["AgreedAmount"]);
                            objRate.AgreedDiscPer = Convert.ToDecimal(dr["AgreedDiscPer"]);
                            objRate.AgreedDiscAmount = Convert.ToDouble(dr["AgreedDiscAmount"]);
                            objRate.RateCardID = Convert.ToInt16(dr["RateCardID"]);
                            objRate.AdRateID = Convert.ToInt16(dr["AdRateID"]);
                            objRate.RateDiff = Convert.ToDouble(dr["RateDiff"]);
                            objRate.BillableArea = Convert.ToDouble(dr["BillableArea"]);
                            objRate.AdsizeID = Convert.ToInt16(dr["SizeID"]);
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
                            objRate.UOM = Convert.ToInt16(dr["UOM"]);
                            objRate.Status = Convert.ToInt16(dr["Status"]);
                            objRate.AuditStatus = Convert.ToInt16(dr["AuditStatus"]);
                            objRate.MaterialType = Convert.ToInt16(dr["MaterialType"]);
                            objRate.MaterialSource = Convert.ToInt16(dr["MaterialSource"]);
                            objRate.ReceiptPayTypeID = Convert.ToInt16(dr["ReceiptPayTypeID"]);
                            objRate.PECode = Convert.ToString(dr["PECode"]);
                            objRate.AdStatus = Convert.ToString(dr["AdStatus"]);
                            objRate.PremiaName = Convert.ToString(dr["PremiaName"]);
                            objRate.SizeName = Convert.ToString(dr["SizeName"]);
                            objRate.ColorName = Convert.ToString(dr["ColorName"]);
                            objRate.BillableSize = Convert.ToString(dr["BillableSize"]);
                            objRate.MaterialID = Convert.ToString(dr["MaterialID"]);
                            objRate.ReadOnlyFlag = Convert.ToString(dr["ReadOnlyFlag"]);
                            objRate.MaterialTypeDescription = Convert.ToString(dr["MaterialTypeDescription"]);
                            objRate.ItemRateFieldChanged = Convert.ToInt16(dr["ItemRateFieldChanged"]);
                            objRate.PackageIDSent = Convert.ToInt16(dr["PackageIDSent"]);
                            objRate.StartDate = Convert.ToDateTime(dr["StartDate"]).ToString("dd/MM/yyyy");
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

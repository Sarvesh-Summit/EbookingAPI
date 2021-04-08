using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBookingCompleteAPI.Models
{
    public class ControlData
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public int Flag { get; set; }
        public string CategoryID { get; set; }
        public string IsLogoPossible { get; set; }
        public string HeightLogo { get; set; }
        public int InsNumber { get; set; }
        public int PackageID { get; set; }
        public int StylePackageID { get; set; }
        public string PackageName { get; set; }
        public int PEID { get; set; }
        public string PECode { get; set; }
        public int ValidDays { get; set; }
        public string AdSizeValue { get; set; }
        public double AdHeight { get; set; }
        public double AdSizeColumn { get; set; }
        public double MinColumn { get; set; }
        public double MaxColumn { get; set; }
        public double MinHeight { get; set; }
        public double MaxHeight { get; set; }
        public double BoxChargePer { get; set; }
        public double BoxChargeAmount { get; set; }

        public int DisplayRateCardID { get; set; }
        public int ClassifiedRateCardID { get; set; }
        public int DisplayCommissionID { get; set; }
        public int ClassifiedCommissionID { get; set; }
        public int AllowCasualClient { get; set; }
        public int AgencyPaymentmode { get; set; }
        public int EmbargoID { get; set; }
        public string EmbargoReason { get; set; }
        public int AllowROL { get; set; }
        public int AllowCD { get; set; }
        public int AllowBoxtype { get; set; }
        public int BackBookingDays { get; set; }
        public double WriteOffAmount { get; set; }
        public double MaxDiscountForAutoApproval { get; set; }
        public int TextTypingInBooking { get; set; }
        public int AutoFolderCreationforClassifiedorders { get; set; }
        public int IsSMENecessaryForBookingOrder { get; set; }
        public int isMaterialTypeRequired { get; set; }
        public int DefaultColorForDispAd { get; set; }
        public int DisplayUOM { get; set; }
        public int DefaultPkgID { get; set; }
        public string Message { get; set; }
        public string BankBranchCode { get; set; }
        public string BankID { get; set; }
        public string BranchID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public int AllowBooking { get; set; }
        public int AllowDisplayBooking { get; set; }
        public int AllowClassifiedBooking { get; set; }
        public int AllowCreditBooking { get; set; }
        public int AllowManualBooking { get; set; }
        public int AllowSuspendOrder { get; set; }
        public int AllowCancelOrder { get; set; }
        public int AllowReceiptCancellation { get; set; }
        public int AllowVATModification { get; set; }
        public int AllowWTModification { get; set; }
        public int IsBrandNecessary { get; set; }
        public int IsProductNecessary { get; set; }
        public string ClassifiedMaterialPath { get; set; } 		
        public string JobPath { get; set; }
        public string ROFilePath { get; set; }
        public string ClMatPath { get; set; }
        public string PendingROID { get; set; }
    }
}
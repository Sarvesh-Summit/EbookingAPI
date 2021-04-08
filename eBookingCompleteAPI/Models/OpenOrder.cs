using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBookingCompleteAPI.Models
{

    public class OpenOrder
    {
        public string StartCol { get; set; }
        public string Yposition { get; set; }
        public string BoxNumber { get; set; }
        public int RevenueCentreID { get; set; }
        public int BookingCentreID { get; set; }
        public int IsClassified { get; set; }
        public int IsDigital { get; set; }
        public string RODate { get; set; }
        public string BookingDate { get; set; }
        public int BookingExecID { get; set; }
        public string BookingNumber { get; set; }
        public string RONumber { get; set; }
        public int AgencyID { get; set; }
        public int ClientID { get; set; }
        public int AgentID { get; set; }
        public int CanvassorID { get; set; }
        public int ROType { get; set; }
        public int BillingCycle { get; set; }
        public int BillTo { get; set; }
        public int BillType { get; set; }
        public int PaymentModeID { get; set; }
        public int IsManualBilling { get; set; }
        public int SourceOrder { get; set; }
        public int ROStatus { get; set; }
        public int RateFieldChanged { get; set; }
        public int ProductID { get; set; }
        public int BrandID { get; set; }
        public int SMEID { get; set; }
        public int BoxTypeID { get; set; }
        public Int64 ROID { get; set; }
        public Int64 BookingID { get; set; }
        public int InsNum { get; set; }
        public int PEID { get; set; }
        public int ReleaseID { get; set; }
        public int ProdPEID { get; set; }
        public int ProdReleaseID { get; set; }
        public string ScheduledDate { get; set; }
        public int PackageID { get; set; }
        public string PkgIDs { get; set; }
        public int AdTypeID { get; set; }
        public int PremiaID { get; set; }
        public int ColorID { get; set; }
        public int Status { get; set; }
        public int AuditStatus { get; set; }
        public int Free_or_Paid { get; set; }
        public int FreeAds { get; set; }
        public int PaidAds { get; set; }
        public int ItemRateFieldChanged { get; set; }
        public int RateCardID { get; set; }
        public int AdRateID { get; set; }
        public double CardRate { get; set; }
        public double CardAmount { get; set; }
        public double AgreedRate { get; set; }
        public double AgreedAmount { get; set; }
        public double PECardBaseRate { get; set; }
        public double ColorRate { get; set; }
        public double PremiaRate { get; set; }
        public decimal AgreedDiscPer { get; set; }
        public double AgreedDiscAmount { get; set; }
        public double CommissionPer { get; set; }
        public double CommissionAmount { get; set; }
        public double DisCountColorPer { get; set; }
        public double DisCountPremiaPer { get; set; }
        public double ExtraDiscountforPE { get; set; }
        public double ExtraChargesForPE { get; set; }
        public double ExtraChargesPer { get; set; }
        public double ExtraDiscPer { get; set; }
        public double ExtraDiscAmount { get; set; }
        public double ExtraBoxChargesPer { get; set; }
        public double ExtraBoxChargesAmount { get; set; }
        public double PreVATAmountforPE { get; set; }
        public double NetAmountforPE { get; set; }
        public double Net { get; set; }
        public double Receivable { get; set; }
        public double VatPer { get; set; }
        public double VatAmount { get; set; }
        public double WTPer { get; set; }
        public double WTAmount { get; set; }
        public string MaterialID { get; set; }
        public int AdsizeID { get; set; }
        public string Adsize { get; set; }
        public double AdSizeHeight { get; set; }
        public double AdSizeWidth { get; set; }
        public string BillableSize { get; set; }
        public double BillableColSize { get; set; }
        public double BillableHeight { get; set; }
        public double BillableArea { get; set; }
        public int UOM { get; set; }
        public int SchemeID { get; set; }
        public int SchemeDetailID { get; set; }
        public int MaterialSource { get; set; }
        public int MaterialType { get; set; }
        public int MaterialStatus { get; set; }
        public string AgencyName { get; set; }
        public string ClientName { get; set; }
        public string CasualClientName { get; set; }
        public string CanvassorName { get; set; }
        public string UserName { get; set; }
        public string CentreName { get; set; }
        public string MaterialPath { get; set; }
        public string JobPath { get; set; }
        public string ROFilePath { get; set; }
        public string PremiaName { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public int CustomerTypeID { get; set; }
        public int IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public double ColumnSize { get; set; }
        public double Gutter { get; set; }
        public string SchedulingInstructions { get; set; }
        public string BillingInstruction { get; set; }
        public string ProdInstructions { get; set; }
        public string Caption { get; set; }
        public string CasualAddress { get; set; }
        public int CityID { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string NicNumber { get; set; }
        public string VatNumber { get; set; }
        public string MBodyCount { get; set; }
        public string AdClassification { get; set; }
        public int AdtypeID1 { get; set; }
        public int AdtypeID2 { get; set; }
        public int AdtypeID3 { get; set; }
        public int AdtypeID4 { get; set; }
        public int AllowCasualClient { get; set; }
        public string BoxAddress { get; set; }
        public int IsCancelReceipt { get; set; }
        public int IsCD { get; set; }
        public int StyleSheetID { get; set; }
        public int IsLogo { get; set; }
        public string U_BodyText { get; set; }
        public string TotalWords { get; set; }
        public string CharCount { get; set; }
        public string PECode { get; set; }
        public string AdStatus { get; set; }
        public string FileNames { get; set; }
        public string ReasonForUnconfirmationID { get; set; }
        public string FileHeight { get; set; }
        public string ReadOnlyFlag { get; set; }
        public string BlockB4ScheduledDate { get; set; }
        public string AdColumns { get; set; }
        public string MaterialTypeDescription { get; set; }
        public int DeferredPayment { get; set; }
        public int AgencyPaymentMode { get; set; }
        public string CompositeReceiptID { get; set; }
        public int IsVatChange { get; set; }
        public int IsTaxChange { get; set; }
        public string StartDate { get; set; }

    }

    public class ROFilesOrder
    {
        // RO Files Details
        public Int64 ROID { get; set; }
        public string ROFileName { get; set; }
        public string ROFileType { get; set; }
        public string ROFileTitle { get; set; }

    }

    public class ReceiptOrder
    {

        // Receipt Details
        public Int64 ReceiptID { get; set; }
        public Int64 ReceiptNumber { get; set; }
        public int ReceiptPaymentMode { get; set; }
        public int BankID { get; set; }
        public int BranchID { get; set; }
        public string CheckNumber { get; set; }
        public double Amount { get; set; }
        public double TotalAmountPaid { get; set; }
        public double WriteOffAmount { get; set; }
        public double CashRefund { get; set; }
        public double CashReceived { get; set; }

    }

    public class CompositeReceiptOrder
    {

        // Composite Receipt Details
        public Int64 ReceiptID { get; set; }
        public double TotalAmountPaid { get; set; }
        public double TotalPayableAmount { get; set; }
        public double WriteOffAmount { get; set; }
        public Int64 LogUserID { get; set; }
        public int ReceiptStatus { get; set; }
        public string ReceiptRemarks { get; set; }
        public string CancelDate { get; set; }
        public string BillingRemarks { get; set; }
        public string CancellationRemarks { get; set; }
        public string ReceiptDate { get; set; }
        public double AdvancedUsed { get; set; }
        public double AdvancedRecieved { get; set; }
        public int ReceiptCentreID { get; set; }
        public Int64 ReceiptNumber { get; set; }
        public int IsClassified { get; set; }
        public int CancelledUserId { get; set; }
        public int AgencyID { get; set; }
        public int ClientID { get; set; }
        public string CasualClient { get; set; }
        public string AgencyName { get; set; }
        public int BillTo { get; set; }
        public int RevenueCentreid { get; set; }
        public string MachineName { get; set; }
        public string CasualAddress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public int ReceiptPaymentMode { get; set; }
        public int BankID { get; set; }
        public string CheckNumber { get; set; }
        public string PaymentDate { get; set; }
        public double Amount { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public int BranchID { get; set; }
        public string BankBranchCode { get; set; }
        public double CashReceived { get; set; }
        public double CashRefund { get; set; }
        public Int64 AdvanceReceiptID { get; set; }
    }

    public class CompositeReceiptROID
    {

        // Composite Receipt Details
        public string ROID { get; set; }
        public double Net { get; set; }
    }

}
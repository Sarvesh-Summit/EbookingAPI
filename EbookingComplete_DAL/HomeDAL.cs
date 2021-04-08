using DBInterface;
using System;
using System.Data;

namespace EbookingComplete_DAL
{
    public class HomeDAL
    {
        public DataSet GeteBookingLoginData(string xmlData)
        {
            using (var db = new DBManager())
            {
                db.Open();
                DataSet ds = db.ExecuteDataSet(CommandType.Text, xmlData);
                return ds;
            }
        }

        public DataSet GeteBookingUserDetails(string xmlData)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var db = new DBManager())
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@XMLBody", xmlData);
                    ds = db.ExecuteDataSet(CommandType.StoredProcedure, "EBK_SP_eBookingFilters");
                    return ds;
                }
            }
            catch (Exception ex)
            {
                Utility.ReportLogError("SP_Name::EBK_SP_eBookingFilters:", ex, xmlData);
            }
            return ds;
        }

        public DataSet GeteBookingControlData(string xmlData)
        {
            DataSet ds = new DataSet();
            //Utility.ReportXMLLog("SP_Name::EBK_SP_eBookingFilters:", xmlData);
            try
            {
                using (var db = new DBManager())
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@XMLBody", xmlData);
                    ds = db.ExecuteDataSet(CommandType.StoredProcedure, "EBK_SP_eBookingFilters");
                 }
            }
            catch (Exception ex)
            {
                Utility.ReportLogError("SP_Name::EBK_SP_eBookingFilters:", ex, xmlData);
            }
            return ds;
        }

        public DataSet GeteBookingRateData(string xmlData)
        {
            DataSet ds = new DataSet();
            Utility.ReportXMLLog("SP_Name::EBK_SP_GetAdRatesXML:", xmlData);
            try
            {
                using (var db =  new DBManager())
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@XMLBody", xmlData);
                    ds = db.ExecuteDataSet(CommandType.StoredProcedure, "EBK_SP_GetAdRatesXML");
                }
            }
            catch (Exception ex)
            {
                Utility.ReportLogError("SP_Name::EBK_SP_GetAdRatesXML:", ex, xmlData);
            }
            return ds;
        }

        public DataSet BookOrdersXML(string xmlData)
        {
            DataSet ds = new DataSet();
            Utility.ReportXMLLog("SP_Name::EBK_SP_BookOrdersXML:", xmlData);
            try
            {
                using (var db = new DBManager())
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@XMLBody", xmlData);
                    ds = db.ExecuteDataSet(CommandType.StoredProcedure, "EBK_SP_BookOrdersXML");
                }
            }
            catch (Exception ex)
            {
                Utility.ReportLogError("SP_Name::EBK_SP_BookOrdersXML:", ex, xmlData);
            }
            return ds;
        }

        public DataSet eBookingActions(string xmlData)
        {
            DataSet ds = new DataSet();
            Utility.ReportXMLLog("SP_Name::EBK_SP_eBookingActions:", xmlData);
            try
            {
                using (var db = new DBManager())
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@XMLBody", xmlData);
                    ds = db.ExecuteDataSet(CommandType.StoredProcedure, "EBK_SP_eBookingActions");
                }
            }
            catch (Exception ex)
            {
                Utility.ReportLogError("SP_Name::EBK_SP_eBookingActions:", ex, xmlData);
            }
            return ds;
        }

        public DataSet eBookingIsCheckprint(string query)
        {

            using (var db = new DBManager())
            {
                db.Open();
                DataSet ds = db.ExecuteDataSet(CommandType.Text, query);
                return ds;
            }

        }

        public int GeteBookingUnlockOrder(int userid, int centerid)
        {
            using (var db = new DBManager())
            {
                db.Open();
                db.CreateParameters(4);
                db.AddParameters(0, "@UserID", userid);
                db.AddParameters(1, "@LoginCentre", centerid);
                db.AddParameters(2, "@ModuleID", 25);
                db.AddParameters(3, "@SubModule", "");
                int a = db.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_SP_UnlockOrder");
                return a;
            }
        }

        public DataSet BookNewReceiptXML(string xmlData)
        {
            DataSet ds = new DataSet();
            Utility.ReportXMLLog("SP_Name::EBK_SP_CreateReceiptXML:", xmlData);
            try
            {
                using (var db = new DBManager())
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@XMLBody", xmlData);
                    ds = db.ExecuteDataSet(CommandType.StoredProcedure, "EBK_SP_CreateReceiptXML");
                }
            }
            catch (Exception ex)
            {
                Utility.ReportLogError("SP_Name::EBK_SP_CreateReceiptXML:", ex, xmlData);
            }
            return ds;
        }


    }
}

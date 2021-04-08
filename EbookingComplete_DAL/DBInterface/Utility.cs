using System;
using System.IO;
using System.Web;
/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{

    public static string ConvertJsonToXML()
    {
        string strXml = "";

        return strXml;
    }
    public static void ReportError(string message, Exception exceptionMessage)
    {
        try
        {
            //string path = "";// HttpContext.Current.Server.MapPath("~/log.txt");            
            //if (true)//System.Web.Configuration.WebConfigurationManager.AppSettings["IsLogGenerate"] == "1")
            string path = HttpContext.Current.Server.MapPath("~/log.txt");
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["IsLogGenerate"] == "1")
            {
                StreamWriter objStreamWriter;
                if (!File.Exists(path))
                    objStreamWriter = new StreamWriter(path);
                else
                    objStreamWriter = File.AppendText(path);
                objStreamWriter.WriteLine("Data Time:" + DateTime.Now);
                objStreamWriter.WriteLine("----------" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "-----------------\n" + exceptionMessage.Message);
                objStreamWriter.Close();
            }
        }
        catch (Exception ex) { }
    }


    public static void ReportLogError(string message, Exception exceptionMessage,string xmlData)
    {
        try
        {
            string path = HttpContext.Current.Server.MapPath("~/log.txt");            
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["IsLogGenerate"] == "1")
            {
                StreamWriter objStreamWriter;
                if (!File.Exists(path))
                    objStreamWriter = new StreamWriter(path);
                else
                    objStreamWriter = File.AppendText(path);
                objStreamWriter.WriteLine("Data Time:" + DateTime.Now);
                objStreamWriter.WriteLine("----------" + message + "----------" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "-----------------\n" + exceptionMessage.Message + "-----------------\n" + xmlData);
                objStreamWriter.Close();
            }
        }
        catch (Exception ex) { }
    }

    public static void ReportXMLLog(string message, string xmlData)
    {
        try
        {
            string path = HttpContext.Current.Server.MapPath("~/Xml.txt");
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["IsLogGenerate"] == "1")
            {
                StreamWriter objStreamWriter;
                if (!File.Exists(path))
                    objStreamWriter = new StreamWriter(path);
                else
                    objStreamWriter = File.AppendText(path);
                objStreamWriter.WriteLine("Data Time:" + DateTime.Now);
                objStreamWriter.WriteLine("----------" + message + "----------" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "-----------------\n" + xmlData);
                objStreamWriter.Close();
            }
        }
        catch (Exception ex) { }
    }

    public static void SaveToLog(string message)
    {
        try
        {
            string path = "";//  HttpContext.Current.Server.MapPath("~/log.txt");
            if (true)//System.Web.Configuration.WebConfigurationManager.AppSettings["IsLogGenerate"] == "1")
            {
                StreamWriter objStreamWriter;
                if (!File.Exists(path))
                    objStreamWriter = new StreamWriter(path);
                else
                    objStreamWriter = File.AppendText(path);
                objStreamWriter.WriteLine("Data Time:" + DateTime.Now);
                objStreamWriter.WriteLine("----------" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "-----------------\n" + message);
                objStreamWriter.Close();
            }
        }
        catch (Exception ex) { }
    }
}

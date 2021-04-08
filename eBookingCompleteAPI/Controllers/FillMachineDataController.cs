using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class FillMachineDataController : ApiController
    {
        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public BookingDetail Post(BookingDetail objbookingDetail)
        {
            try
            {
                string strXml = "<ebooking><actionname>getmachinename</actionname>"
                                + "<loguserid>" + objbookingDetail.UserId + "</loguserid>"
                               + "<revenuecentreid>" + objbookingDetail.RevenueCentreID + "</revenuecentreid>"
                               + "<machinename>" + objbookingDetail.MachineName + "</machinename></ebooking>";
                DataTable objdt = objHomeDAL.GeteBookingControlData(strXml).Tables[0];
                foreach (DataRow dr in objdt.Rows)
                {
                    objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0][0]);
                    if (objbookingDetail.IsValid == -2)
                    {
                        objbookingDetail.IsValid = Convert.ToInt16(objdt.Rows[0]["ErrorFlag"]);
                        objbookingDetail.ErrorMessage = Convert.ToString(objdt.Rows[0]["ErrorMessage"]);
                    }
                    else
                    {
                        objbookingDetail.MachineID = Convert.ToString(objdt.Rows[0]["MachineID"]);
                        objbookingDetail.MachineName = Convert.ToString(objdt.Rows[0]["MachineName"]);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return objbookingDetail;
        }
    }
}

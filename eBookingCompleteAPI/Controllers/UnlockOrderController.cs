using EbookingComplete_DAL;
using eBookingCompleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace eBookingCompleteAPI.Controllers
{
    public class UnlockOrderController : ApiController
    {
        HomeDAL objHomeDAL = new HomeDAL();
        [HttpPost]
        public void Post(BookingDetail objbookingDetail)
        {
           
            try
            {
                int result = objHomeDAL.GeteBookingUnlockOrder(objbookingDetail.UserId, objbookingDetail.RevenueCentreID);
            }
            catch (Exception ex)
            {
            }
        }
    }
}

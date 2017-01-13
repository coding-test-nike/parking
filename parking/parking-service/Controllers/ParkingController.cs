using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System;

namespace parking_service.Controllers
{
    [RoutePrefix("api")]
    public class ParkingController : ApiController
    {
         
        /// <summary>
        /// Returns number of parking spots available
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            Random r = new Random();
            int num = r.Next(50);
            return Ok(num);
        }

        /// <summary>
        /// Gets the parking charges based on parking in time and out time
        /// </summary>
        /// <param name="timeIn">In time to be provided in {yyyymmddhhmmss}</param>
        /// <param name="timeOut">Out time to be provided in {yyyymmddhhmmss}</param>
        /// <returns></returns>
        [Route("fees/{timeIn}/{timeOut}")]
        public IHttpActionResult Get(string timeIn, string timeOut)
        {
            var hours = (getDateTime(timeOut) - getDateTime(timeIn)).TotalHours;
             
            int fee =0;
            if (hours <=2)
            {
                fee = 5;
            }
            else if (hours>2 && hours <=10)
            {
                fee = 10;
            }
            else if (hours > 10)
            {
                fee = 15;
            }

            return Ok(fee);
        }

        private DateTime getDateTime(string val)
        {
            DateTime dt = DateTime.ParseExact(val, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);

            return dt;
        }
    }
}

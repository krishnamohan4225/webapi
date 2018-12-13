using BiharITI.DATA;
using System;
using System.Net;
using System.Web.Http;

namespace BiharITI.Controllers
{
    public class VehicleTrackingController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SaveGps(string Latitude, string Longitude, int deviceid,string devicename)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    DATA.VehicleTracking gps = new VehicleTracking();
                    gps.Latitude = Latitude;
                    gps.Longitude = Longitude;
                    gps.deviceid = deviceid;
                    gps.DeviceTime = devicename;
                    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    DateTime timeUtc = DateTime.UtcNow;
                    DateTime result = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeZoneInfo);
                    gps.updatedDate = result;
                    DB.VehicleTrackings.Add(gps);
                    DB.SaveChanges();
                }
                var response = new
                {
                    Success = true,
                    Message = "GPS Coorinates saved Successfully",
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error Found");
            }
        }

    }
}

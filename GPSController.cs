using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BiharITI.DATA;
using Newtonsoft.Json;
using System.Text;

namespace BiharITI.Controllers
{
    public class GPSController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SaveGps(string Latitude, string Longitude, string DTime)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    DATA.GP gps = new GP();
                    gps.lat = Latitude;
                    gps.longitude = Longitude;
                    gps.updatedDate= DateTime.UtcNow;
                    gps.DeviceTime = DTime;
                    gps.deviceid = "1";
                    DB.GPS.Add(gps);
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

        [HttpGet]
        public IHttpActionResult SaveGps(string Latitude, string Longitude)
        {
            try
            { 
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    DATA.GP gps = new GP();
                    gps.lat = Latitude;
                    gps.longitude = Longitude;
                    gps.updatedDate = DateTime.UtcNow;
                    gps.deviceid = "1";
                    DB.GPS.Add(gps);
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



        [HttpGet]
        public IHttpActionResult SaveGps(string Latitude, string Longitude, int deviceid, string devicename)
        { 
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    DATA.VehicleTracking gps = new VehicleTracking();
                    gps.Latitude = Latitude;
                    gps.Longitude = Longitude;
                    gps.deviceid = deviceid;
                    gps.devicename = devicename;
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

        [HttpGet]
        [Route("api/VehicleTracking")]
        public HttpResponseMessage GetGPS()
        {
            try
            {
               var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var gps = DB.VehicleTrackings.ToList();
                    gpsJson = JsonConvert.SerializeObject(gps);
                }
                var response = this.Request.CreateResponse(HttpStatusCode.OK,gpsJson);
                response.Content = new StringContent(gpsJson, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/GPS/GetGPS/{order}")]
        public HttpResponseMessage GetGPS(string order)
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var gps = DB.GPS.FirstOrDefault();
                    gpsJson = JsonConvert.SerializeObject(gps);
                }
                var response = this.Request.CreateResponse(HttpStatusCode.OK, gpsJson);
                response.Content = new StringContent(gpsJson, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }

   
}

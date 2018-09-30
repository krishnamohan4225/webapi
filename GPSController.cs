using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using smartpond.DATA;
using Newtonsoft.Json;
using System.Text;

namespace smartpond.Controllers
{
    public class GPSController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SaveGps(string Latitude, string Longitude, string DTime)
        {
            try
            {
                using (smartpondEntities DB = new smartpondEntities())
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
                using (smartpondEntities DB = new smartpondEntities())
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
        public HttpResponseMessage GetGPS()
        {
            try
            {
               var gpsJson = "";
                using (smartpondEntities DB = new smartpondEntities())
                {
                    var gps = DB.GPS.ToList();
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
                using (smartpondEntities DB = new smartpondEntities())
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

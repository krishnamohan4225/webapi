using BiharITI.DATA;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;


namespace smartpond.Controllers
{
    public class SmartTemperatureController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SaveTemperature(decimal temp, decimal faht,int deviceid, string devicename)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    BiharITI.DATA.Temperature se = new Temperature();
                    se.temp = temp;
                    se.faht = faht;
                    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    DateTime timeUtc = DateTime.UtcNow;
                    DateTime result = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeZoneInfo);
                    se.updatedDate = result;
                    se.deviceid = deviceid;
                    se.devicename = devicename;
                    DB.Temperatures.Add(se);
                    DB.SaveChanges();
                }
                var response = new
                {
                    Success = true,
                    Message = "Temperature data posted",
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Error Found");
            }
        }

        [Route("api/Temperature")]
        public HttpResponseMessage GetTemperature()
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var temp = DB.Temperatures.ToList();
                    gpsJson = JsonConvert.SerializeObject(temp);
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

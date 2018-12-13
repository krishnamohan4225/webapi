using Newtonsoft.Json;
using BiharITI.DATA;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BiharITI.Controllers
{
    public class SmartElectricityMeterController : ApiController
    {

        [HttpGet]
        public IHttpActionResult SaveElectricity(decimal v, decimal c, decimal units, int deviceid, string devicename)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    BiharITI.DATA.ElectricityMeter se = new ElectricityMeter();
                    se.voltage = v;
                    se.currentamp = c;
                    se.Units = units;
                    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    DateTime timeUtc = DateTime.UtcNow;
                    DateTime result = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeZoneInfo);
                    se.updatedDate = result;
                    se.deviceid = deviceid;
                    se.devicename = devicename;
                    DB.ElectricityMeters.Add(se);
                    DB.SaveChanges();
                }
                var response = new
                {
                    Success = true,
                    Message = "Electricity data saved",
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Error Found");
            }
        }

        [HttpGet]
        [Route("api/ElectricityMeter")]
        public HttpResponseMessage GetSmartElectricityMeter()
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var gps = DB.ElectricityMeters.ToList();
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

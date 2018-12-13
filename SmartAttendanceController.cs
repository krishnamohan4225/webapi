using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BiharITI.DATA;
using Newtonsoft.Json;
using System.Text;
using System.Web.Http.Cors;

namespace BiharITI.Controllers
{
    public class SmartAttendanceController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SaveFingerprintID(int fingerID, string message, int deviceid, string devicename)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    DATA.attendance attendance = new attendance();
                    attendance.deviceid = deviceid;
                    attendance.devicename = devicename;
                    attendance.fingerid = fingerID;
                    attendance.message = message;
                    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    DateTime timeUtc = DateTime.UtcNow;
                    DateTime result = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeZoneInfo);
                    attendance.updatedDate = result;
                    //  var status = DB.attendances.ToList().Where(x=>x.deviceid==deviceid).OrderByDescending(x=>x.id).Take(1);

                    var latesttime_fingerId = (from a in DB.attendances
                                               where a.fingerid == fingerID
                                               select a)
.OrderByDescending(x => x.id)
.Take(1)
.Select(x => x.updatedDate).FirstOrDefault();
                    var lateststatus_fingerid = (from a in DB.attendances
                                               where a.fingerid == fingerID
                                               select a)
.OrderByDescending(x => x.id)
.Take(1)
.Select(x => x.status).FirstOrDefault();

                    DateTime latesttime =Convert.ToDateTime( latesttime_fingerId);
                    if (latesttime.Day == result.Day  && lateststatus_fingerid=="IN")
                    {
                        attendance.status = "OUT";
                    }

                    else if (latesttime.Day < result.Day)
                    {
                        attendance.status = "IN";
                    }
                    else 
                    {
                        attendance.status = "INVALID";
                    }
                    DB.attendances.Add(attendance);
                    DB.SaveChanges();
                }
                var response = new
                {
                    Success = true,
                    Message = "attendance saved",
                };
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Content(HttpStatusCode.BadRequest, "Error Found");
            }
        }

        [Route("api/Attendance")]
        public HttpResponseMessage GetTemperature()
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var temp = DB.attendances.ToList();
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

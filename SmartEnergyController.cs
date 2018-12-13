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
    public class SmartEnergyController : ApiController
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
                    gps.updatedDate = DateTime.UtcNow;
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

        //[HttpGet]
        //public IHttpActionResult SaveEnergy(int v, int c,int pf, int f)
        //{
        //    try
        //    {
        //        using (kernels1_itiEntities DB = new kernels1_itiEntities())
        //        {
        //            DATA.SmartEnergy se = new SmartEnergy();
        //            se.Voltage = v;
        //            se.CurrentValue = c;
        //            se.Frequency = f;
        //            se.PowerFactor = pf;
        //            se.updatedDate = DateTime.UtcNow;
        //            se.deviceid = 1;
        //            DB.SmartEnergies.Add(se);
        //            DB.SaveChanges();
        //        }
        //        var response = new
        //        {
        //            Success = true,
        //            Message = "Energy data posted",

        //        };
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(HttpStatusCode.BadRequest, "Error Found");
        //    }
        //}

        //save enery api with device id  and name
        [HttpGet]
        public IHttpActionResult SaveEnergy(decimal v, decimal c, decimal pf, decimal f, int deviceid,string devicename)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    DATA.SmartEnergy se = new SmartEnergy();
                    se.voltage = v;
                    se.currentamp = c;
                    se.frequency = f;
                    se.powerfactor = pf;
                    se.updatedDate = DateTime.UtcNow;
                    se.deviceid = deviceid;
                    se.devicename = devicename;
                    DB.SmartEnergies.Add(se);
                    DB.SaveChanges();
                }
                var response = new
                {
                    Success = true,
                    Message = "Energy data posted",
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Error Found");
            }
        }
        [HttpGet]
        public IHttpActionResult SaveElecMeter(int v, int c, int u)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    DATA.SmartElectricityMeter sem = new SmartElectricityMeter();
                    sem.Voltage = v;
                    sem.CurrentValue = c;
                    sem.Units = u;
                    sem.updatedDate = DateTime.UtcNow;
                    sem.deviceid = 1;
                    DB.SmartElectricityMeters.Add(sem);
                    DB.SaveChanges();
                }
                var response = new
                {
                    Success = true,
                    Message = "Elect Meter data posted",

                };
                return Ok(response);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Error Found");
            }
        }

        [HttpGet]
        [Route("api/Energy")]
        public HttpResponseMessage GetSmartEnergy()
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var gps = DB.SmartEnergies.ToList();
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
        [HttpGet]
        [Route("api/ElecMeter")]
        public HttpResponseMessage GetElecMeter()
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var gps = DB.SmartElectricityMeters.ToList();
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

        [HttpGet]
        [Route("api/SmartEnergy/GetSmartEnergyL/{order}")]
        public HttpResponseMessage GetSmartEnergyL(string order)
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var gps = DB.SmartEnergies.FirstOrDefault();
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

        [Route("api/SmartEnergy/GetElecMeterL/{order}")]
        public HttpResponseMessage GetElecMeter(string order)
        {
            try
            {
                var gpsJson = "";
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    var gps = DB.SmartElectricityMeters.FirstOrDefault();
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

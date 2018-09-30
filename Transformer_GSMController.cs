using smartpond.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace smartpond.Controllers
{
    public class Transformer_GSMController : ApiController
    {
        [HttpGet]
        [Route("TRANSFORMER_SCADA")]
        public IHttpActionResult GSM(int EventId,string DeviceImei,DateTime DeviceTimeStamp,string MachineName,int OTI,int WTI,int ATI,int OLI,int OLTC_WTI, int HUM, int OTIA, int OTIT,int WTIA,int WTIT,int GORA,int GORT,int MOGA,int SRT,int PRVT,int OLTCSURGE,int OLTCPRV, int IN1,int IN2, int FAN1, int FAN2,int OUT1, int OUT2, int OUT3, int OUT4, string GridStatus,string PIR, double VL1, double VL2, double VL3,double IL1, double IL2, double IL3,double VL12, double VL23, double VL31,int AVL, double INUT,double WL1, double WL2, double WL3,double VAL1, double VAL2, double VAL3,double RVAL1, double RVAL2, double RVAL3, double PFL1, double PFL2, double PFL3, double SUMPF, double SUMPA, double FRQ, double THDVL1, double THDVL2, double THDVL3, double THDIL1, double THDIL2, double THDIL3, double MDIL1, double MDIL2, double MDIL3, double KWH, double KVARH, double I, double KW, double KVA, double KVAR, double MPD, double MKVAD)
        {
            try
            {
                using (smartpondEntities DB = new smartpondEntities())
                {
                    //74 parameters
                    DATA.Transformer_GSM  oltms= new Transformer_GSM();
                    oltms.EventId = EventId;
                    oltms.DeviceImei = DeviceImei;
                    oltms.DeviceTimeStamp=DeviceTimeStamp;
                    oltms.MachineName = MachineName;
                    oltms.OTI = OTI;
                    oltms.WTI = WTI;
                    oltms.ATI = ATI;
                    oltms.OLI = OLI;
                    oltms.OLTC_WTI = OLTC_WTI;
                    oltms.HUM = HUM;
                    oltms.OTIA = OTIA;
                    oltms.OTIT = OTIT;
                    oltms.WTIA = WTIA;
                    oltms.WTIT = WTIT;
                    oltms.GORA = GORA;
                    oltms.GORT = GORT;
                    oltms.MOGA = MOGA;
                    oltms.SRT = SRT;
                    oltms.PRVT = PRVT;
                    oltms.OLTCSURGE = OLTCSURGE;
                    oltms.OLTCPRV = OLTCPRV;
                    oltms.IN1 = IN1;
                    oltms.IN2 = IN2;
                    oltms.FAN1 = FAN1;
                    oltms.FAN2 = FAN2;
                    oltms.OUT1 = OUT1;
                    oltms.OUT2 = OUT2;
                    oltms.OUT3 = OUT3;
                    oltms.OUT4 = OUT4;
                    oltms.GridStatus = GridStatus;
                    oltms.PIR = PIR;
                    oltms.VL1 = VL1;
                    oltms.VL2 = VL2;
                    oltms.VL3 = VL3;
                    oltms.IL1 = IL1;
                    oltms.IL2 = IL2;
                    oltms.IL3 = IL3;
                    oltms.VL12 = VL12;
                    oltms.VL23 = VL23;
                    oltms.VL31 = VL31;
                    oltms.AVL = AVL;
                    oltms.INUT = INUT;
                    oltms.WL1 = WL1;
                    oltms.WL2 = WL2;
                    oltms.WL3 = WL3;
                    oltms.VAL1 = VAL1;
                    oltms.VAL2 = VAL2;
                    oltms.VAL3 = VAL3;
                    oltms.RVAL1 = RVAL1;
                    oltms.RVAL2 = RVAL2;
                    oltms.RVAL3 = RVAL3;
                    oltms.PFL1 = PFL1;
                    oltms.PFL2 = PFL2;
                    oltms.PFL3 = PFL3;
                    oltms.SUMPF = SUMPF;
                    oltms.SUMPA = SUMPA;
                    oltms.FRQ = FRQ;
                    oltms.THDVL1 = THDVL1;
                    oltms.THDVL2 = THDVL2;
                    oltms.THDVL3 = THDVL3;
                    oltms.THDIL1 = THDIL1;
                    oltms.THDIL2 = THDIL2;
                    oltms.THDIL3 = THDIL3;
                    oltms.MDIL1 = MDIL1;
                    oltms.MDIL2 = MDIL2;
                    oltms.MDIL3 = MDIL3;
                    oltms.KWH = KWH;
                    oltms.KVARH = KVARH;
                    oltms.I = I;
                    oltms.KW = KW;
                    oltms.KVA = KVA;
                    oltms.KVAR = KVAR;
                    oltms.MPD = MPD;
                    oltms.MKVAD = MKVAD;
                    DateTime updtime = DateTime.UtcNow;
                    oltms.updtime = updtime;
                   //gps.updatedDate = DateTime.UtcNow;
                    DB.Transformer_GSM.Add(oltms);
                    DB.SaveChanges();
                }
                var response = new
                {
                    Success = true,
                    Message = "Transformer data saved",
                };
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Content(HttpStatusCode.BadRequest, Ex.Message);
            }
        }
    }
}

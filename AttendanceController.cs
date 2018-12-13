using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiharITI.DATA;


namespace BiharITI.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult loaddata()
        {

            using (kernels1_itiEntities dc = new kernels1_itiEntities())
            {
                var data = dc.attendances.OrderBy(a => a.id).ToList();
                return Json(new
                {
                    data = data
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
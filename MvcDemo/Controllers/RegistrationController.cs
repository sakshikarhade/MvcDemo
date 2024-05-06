using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult RegIndex()
        {
            return View();
        }
        public ActionResult DetailIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult Savereg(RegistrationModel model)
        {
            try

            {
                return Json(new { Message =new RegistrationModel().Savereg(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetRegistrationList()
        {
            try

            {
                return Json(new { model = new RegistrationModel().GetRegistrationList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DeleteRegistration(int Id)
        {
            try

            {
                return Json(new { model = new RegistrationModel().DeleteRegistration(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetRegisterbyId(int Id)
        {
            try

            {
                return Json(new { model = new RegistrationModel().GetRegisterbyId(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}



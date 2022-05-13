using BAL.Repositories;
using DAL.DBEntities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPGarageAdmin.Controllers
{
    public class BroadcastController : Controller
    {
        broadcastRepository repo;
        public BroadcastController()
        {
            repo = new broadcastRepository(new Garage_UATEntities());

        }

        [HttpPost]
        public JsonResult Send(BroadcastViewModel modal, string isEmail)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
            {
                try
                {
                    if (isEmail == "Email")
                    {
                        var cusemail = repo.SendEmailCustomer(modal);
                        var adminemail = repo.SendEmailToAdmin(modal);
                        if (cusemail == 1 && adminemail == 1)

                            return Json(new { success = true });
                        else
                            return Json(new { success = false });
                    }
                    else
                    {
                        var sms = repo.Smsdirect(modal);
                        if (sms == "success")

                            return Json(new { success = true });
                        else
                            return Json(new { success = false });

                    }
                }

                catch (Exception ex)
                {

                    throw;
                }
            }
            else { 
            return Json(new { success = isSuccess }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: itemmovement
        public ActionResult Broadcast(int? userid, string fDate, string tDate)
        {
            var listUsers = repo.getAllUsers();
            ViewBag.Users = listUsers;
            //ViewBag.Users = new MultiSelectList(listUsers, "UserID", "UserName");
            //int id = 0;

            //if (userid == 0 )
            //{
            //     id = listUsers.FirstOrDefault() != null ? listUsers.FirstOrDefault().UserID : 0;
            //}
            //ViewBag.Data = repo.GetCustomerSMSBills(id, fDate == null ? DateTime.Now.Date.AddDays(-5).ToString() : fDate, tDate == null ? DateTime.Now.Date.ToString() : tDate);
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (TestCRUDEntities db = new TestCRUDEntities())
                {
                    var list = from d in db.Users
                               where d.email == user && d.password == password && d.idState == 1
                               select d;
                    if (list.Count() > 0)
                    {
                        Users oUser = list.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido");
                    }
                }
                    
            }
            catch (Exception e)
            {
                return Content("Error:" + e.Message);
            }
        }
    }
}
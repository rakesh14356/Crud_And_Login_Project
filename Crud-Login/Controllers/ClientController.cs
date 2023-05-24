using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Crud_Login.Models;

namespace Crud_Login.Controllers
{
    public class ClientController : Controller
    {
        DbServicesContext db=new DbServicesContext();
        // GET: Client
        public ActionResult Index()
        {
            return View(db.tbl_Client.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {db.tbl_Client.Add(client);
            int a=db.SaveChanges();

            if(a>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.SubmitMsg = ("<script>alert('Something went wrong ..')</script>");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var a = db.tbl_Client.Where(model => model.Id == id).FirstOrDefault();
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(Client cl)
        {
            db.Entry(cl).State=EntityState.Modified;
           int a =db.SaveChanges();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.EditMsg = ("<script>alert('Something went wrong ..')</script>");
            }
            return View();


           
        }



        public ActionResult Delete(int id)
        {
            var a = db.tbl_Client.Where(model => model.Id == id).FirstOrDefault();
            return View(a);
        }

        [HttpPost]
        public ActionResult Delete(Client cl)
        {
            db.Entry(cl).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.EditMsg = ("<script>alert('Something went wrong ..')</script>");
            }
            return View();



        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Client client)
        {
            var row = db.tbl_Client.Where(model => model.Email == client.Email && model.Password == client.Password).FirstOrDefault() ;
           

            if (row != null)
            {
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.LoginMsg = ("<script>alert('Something went wrong ..')</script>");
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult Welcome()
        {

            return View(db.tbl_Client.ToList());
        }
    }
}
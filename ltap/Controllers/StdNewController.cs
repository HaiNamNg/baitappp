using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ltap.Models;

namespace ltap.Controllers
{
    public class StdNewController : Controller
    {
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        AutoGeneratekey genKey = new AutoGeneratekey();
        // GET: StdNew
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult Create()
        {
            var stdID = "";
            var countStudent = db.Students.Count();
            if (countStudent == 0)
            {
                stdID = "STD001";
            }
            else
            {
                //lay gia tri studenID moi nhat
                var studenID = db.Students.ToList().OrderByDescending(m => m.StudentID).FirstOrDefault().StudentID;
                //sinh StudentID tu dong
                stdID = genKey.Generatekey(studenID);
            }
            ViewBag.StudnetID = stdID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
           if (ModelState.IsValid)
            {
                //luu thong tin vao database
                db.Students.Add(std);
                db.SaveChanges();
                //lay du lieu tu client gui len va luu vao database
                return RedirectToAction("Index");
            }
            return View(std);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GICMicro.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GICMicro.Controllers
{
    public class UsersInfoController : Controller
    {
        Models.LmsDbMyHclContext db = new Models.LmsDbMyHclContext();

        // GET: UsersInfo
        public ActionResult Index()
        {
            //var usersInfoes = db.UsersInfo.include(u => u.CompanyId);
            
            return View(db.UsersInfo.ToList());
        }

        // GET: UsersInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            UsersInfo usersInfo = db.UsersInfo.Find(id);
            if (usersInfo == null)
            {
                return NotFound();
            }
            return View(usersInfo);
        }

        // GET: UsersInfo/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.CompanyId, "CompanyID1", "CustomerCode");
            return View();
        }

        // POST: UsersInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("UserID,UserName,UserEmailID,CreatedDate,CustomerId")] UsersInfo usersInfo)
        {
            if (ModelState.IsValid)
            {
                db.UsersInfo.Add(usersInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.CompanyId, "CompanyID1", "CustomerCode", usersInfo.CustomerId);
            return View(usersInfo);
        }

        // GET: UsersInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            UsersInfo usersInfo = db.UsersInfo.Find(id);
            if (usersInfo == null)
            {
                return NotFound();
            }
            ViewBag.CustomerId = new SelectList(db.CompanyId, "CompanyID1", "CustomerCode", usersInfo.CustomerId);
            return View(usersInfo);
        }

        // POST: UsersInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("UserID,UserName,UserEmailID,CreatedDate,CustomerId")] UsersInfo usersInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.CompanyId, "CompanyID1", "CustomerCode", usersInfo.CustomerId);
            return View(usersInfo);
        }

        // GET: UsersInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            UsersInfo usersInfo = db.UsersInfo.Find(id);
            if (usersInfo == null)
            {
                return NotFound();
            }
            return View(usersInfo);
        }

        // POST: UsersInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersInfo usersInfo = db.UsersInfo.Find(id);
            db.UsersInfo.Remove(usersInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

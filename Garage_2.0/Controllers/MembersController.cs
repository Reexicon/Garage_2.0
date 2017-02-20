using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage_2._0.DAL;
using Garage_2._0.Models;

namespace Garage_2._0.Controllers
{
    public class MembersController : Controller
    {
        private VehiclesContext db = new VehiclesContext();

        // GET: Members
        public ActionResult Index(string sortOrder, string searchFirstName, string searchLastName, string searchPhoneNo, string searchMail)
        {

            ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            ViewBag.LastNameSortParm = sortOrder == "LastName" ? "LastName_desc" : "LastName";
            ViewBag.LastNameSortParm = sortOrder == "PhoneNo" ? "PhoneNo_desc" : "PhoneNo";
            ViewBag.LastNameSortParm = sortOrder == "Mail" ? "Mail_desc" : "Mail";

            ViewBag.SearchFirstName = searchFirstName;
            ViewBag.SearchLastName = searchLastName;
            ViewBag.SearchLastName = searchPhoneNo;
            ViewBag.SearchLastName = searchMail;

            var members = from m in db.Members
                           select m;

            if (!String.IsNullOrEmpty(searchFirstName))
            {
                members = members.Where(m => m.FirstName.Contains(searchFirstName)
                                       );
            }
            if (!String.IsNullOrEmpty(searchLastName))
            {
                members = members.Where(m => m.LastName.Contains(searchLastName)
                                       );
            }

            if (!String.IsNullOrEmpty(searchPhoneNo))
            {
                members = members.Where(m => m.PhoneNo.Contains(searchPhoneNo)
                                       );
            }

            if (!String.IsNullOrEmpty(searchMail))
            {
                members = members.Where(m => m.Mail.Contains(searchMail)
                                       );
            }

            switch (sortOrder)
            {
                case "FirstName":
                    members = members.OrderBy(m => m.FirstName);
                    break;
                case "FirstName_desc":
                    members = members.OrderByDescending(m => m.FirstName);
                    break;
                case "LastName":
                    members = members.OrderBy(m => m.LastName);
                    break;
                case "LastName_desc":
                    members = members.OrderByDescending(m => m.LastName);
                    break;
                case "PhoneNo":
                    members = members.OrderBy(m => m.PhoneNo);
                    break;
                case "PhoneNo_desc":
                    members = members.OrderByDescending(m => m.PhoneNo);
                    break;
                case "Mail":
                    members = members.OrderBy(m => m.Mail);
                    break;
                case "Mail_desc":
                    members = members.OrderByDescending(m => m.Mail);
                    break;
                default:
                    break;
            }
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PhoneNo,Mail")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PhoneNo,Mail")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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

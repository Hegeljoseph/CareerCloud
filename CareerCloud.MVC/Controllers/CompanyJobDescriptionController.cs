using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.MVC.Models;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyJobDescriptionController : Controller
    {
        private CareerCloudMVCContext db = new CareerCloudMVCContext();

        // GET: CompanyJobDescription
        public ActionResult Index()
        {
            return View(db.CompanyJobDescriptionPocoes.ToList());
        }

        // GET: CompanyJobDescription/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptionPocoes.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyJobDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,JobName,JobDescriptions,TimeStamp")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobDescriptionPoco.Id = Guid.NewGuid();
                db.CompanyJobDescriptionPocoes.Add(companyJobDescriptionPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptionPocoes.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,JobName,JobDescriptions,TimeStamp")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobDescriptionPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptionPocoes.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptionPocoes.Find(id);
            db.CompanyJobDescriptionPocoes.Remove(companyJobDescriptionPoco);
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

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
    public class SecurityLoginsRoleController : Controller
    {
        private CareerCloudMVCContext db = new CareerCloudMVCContext();

        // GET: SecurityLoginsRole
        public ActionResult Index()
        {
            return View(db.SecurityLoginsRolePocoes.ToList());
        }

        // GET: SecurityLoginsRole/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRolePocoes.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityLoginsRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Role,TimeStamp")] SecurityLoginsRolePoco securityLoginsRolePoco)
        {
            if (ModelState.IsValid)
            {
                securityLoginsRolePoco.Id = Guid.NewGuid();
                db.SecurityLoginsRolePocoes.Add(securityLoginsRolePoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRole/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRolePocoes.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsRolePoco);
        }

        // POST: SecurityLoginsRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Role,TimeStamp")] SecurityLoginsRolePoco securityLoginsRolePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityLoginsRolePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRole/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRolePocoes.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsRolePoco);
        }

        // POST: SecurityLoginsRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRolePocoes.Find(id);
            db.SecurityLoginsRolePocoes.Remove(securityLoginsRolePoco);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.MVC.Models;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantProfileController : Controller
    {
        private ApplicantProfileLogic logic;

        public ApplicantProfileController()
        {
            IDataRepository<ApplicantProfilePoco> repo = new EFGenericRepository<ApplicantProfilePoco>();
            logic = new ApplicantProfileLogic(repo);
        }
        // GET: ApplicantProfile
        public ActionResult Index()
        {
            return View(logic.GetAll());
        }

        // GET: ApplicantProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = logic.Get(id.Value);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode,TimeStamp")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                applicantProfilePoco.Id = Guid.NewGuid();
                logic.Add(new[] { applicantProfilePoco });
                return RedirectToAction("Index");
            }

            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = logic.Get(id.Value);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode,TimeStamp")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                logic.Update(new[] { applicantProfilePoco });
                return RedirectToAction("Index");
            }
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = logic.Get(id.Value);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantProfilePoco applicantProfilePoco = logic.Get(id);
            logic.Delete(new[] { applicantProfilePoco });
            return RedirectToAction("Index");
        }
    }
}

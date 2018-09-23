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
    public class ApplicantJobApplicationController : Controller
    {
        private ApplicantJobApplicationLogic logic;

        public ApplicantJobApplicationController()
        {
            IDataRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            logic = new ApplicantJobApplicationLogic(repo);
        }

        // GET: ApplicantJobApplication
        public ActionResult Index()
        {
            return View(logic.GetAll());
        }

        // GET: ApplicantJobApplication/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = logic.Get(id.Value);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantJobApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Job,ApplicationDate,TimeStamp")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                applicantJobApplicationPoco.Id = Guid.NewGuid();
                logic.Add(new[] { applicantJobApplicationPoco });
                return RedirectToAction("Index");
            }

            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = logic.Get(id.Value);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Job,ApplicationDate,TimeStamp")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                logic.Update(new[] { applicantJobApplicationPoco });
                return RedirectToAction("Index");
            }
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = logic.Get(id.Value);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantJobApplicationPoco applicantJobApplicationPoco = logic.Get(id);
            logic.Delete(new[] { applicantJobApplicationPoco });
            return RedirectToAction("Index");
        }
    }
}

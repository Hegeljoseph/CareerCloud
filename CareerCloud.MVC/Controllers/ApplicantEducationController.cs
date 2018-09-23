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
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantEducationController : Controller
    {
        private ApplicantEducationLogic logic;

        public ApplicantEducationController()
        {
            IDataRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            logic = new ApplicantEducationLogic(repo);
        }

        // GET: ApplicantEducation
        public ActionResult Index()
        {
            return View(logic.GetAll());
        }

        // GET: ApplicantEducation/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco = logic.Get(id.Value);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Major,CertificateDiploma,StartDate,CompletionDate,CompletionPercent,TimeStamp")] ApplicantEducationPoco applicantEducationPoco)
        {
            if (ModelState.IsValid)
            {
                applicantEducationPoco.Id = Guid.NewGuid();
                logic.Add(new[] { applicantEducationPoco });
                return RedirectToAction("Index");
            }

            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco = logic.Get(id.Value);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Major,CertificateDiploma,StartDate,CompletionDate,CompletionPercent,TimeStamp")] ApplicantEducationPoco applicantEducationPoco)
        {
            if (ModelState.IsValid)
            {
                logic.Update(new[] { applicantEducationPoco });

                return RedirectToAction("Index");
            }
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicantEducationPoco applicantEducationPoco = logic.Get(id.Value);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantEducationPoco applicantEducationPoco = logic.Get(id);
            return RedirectToAction("Index");
        }
    }
}

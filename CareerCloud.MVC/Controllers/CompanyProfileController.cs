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
    public class CompanyProfileController : Controller
    {
        private CompanyProfileLogic logic;

        public CompanyProfileController()
        {
            IDataRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>();
            logic = new CompanyProfileLogic(repo);

        }

        // GET: CompanyProfile
        public ActionResult Index()
        {
            return View(logic.GetAll());
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyProfilePoco companyProfilePoco = logic.Get(id.Value);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                companyProfilePoco.Id = Guid.NewGuid();
                logic.Add( new [] {companyProfilePoco});
                return RedirectToAction("Index");
            }

            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyProfilePoco companyProfilePoco = logic.Get(id.Value);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                logic.Update(new [] {companyProfilePoco});
                return RedirectToAction("Index");
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyProfilePoco companyProfilePoco = logic.Get(id.Value);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyProfilePoco companyProfilePoco = logic.Get(id);
            logic.Delete(new [] {companyProfilePoco});
            
            return RedirectToAction("Index");
        }
        
    }
}

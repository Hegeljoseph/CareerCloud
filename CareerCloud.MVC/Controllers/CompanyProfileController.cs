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
        private CompanyProfileLogic companyProfileLogic;
        private CompanyDescriptionLogic companyDescriptionLogic;


        public CompanyProfileController()
        {
            IDataRepository<CompanyProfilePoco> cpRepo = new EFGenericRepository<CompanyProfilePoco>();
            companyProfileLogic = new CompanyProfileLogic(cpRepo);
            IDataRepository<CompanyDescriptionPoco> cdRepo = new EFGenericRepository<CompanyDescriptionPoco>();
            companyDescriptionLogic = new CompanyDescriptionLogic(cdRepo);
        }

        // GET: CompanyProfile
        public ActionResult Index()
        {
            return View(companyProfileLogic.GetAll());
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyProfilePoco companyProfilePoco = companyProfileLogic.Get(id.Value);
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
        public ActionResult Create(
            [Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")]
            CompanyProfilePoco companyProfilePoco, string CompanyName, string CompanyDescription)
        {
            if (ModelState.IsValid)
            {
                companyProfilePoco.Id = Guid.NewGuid();
                CompanyDescriptionPoco companyDescriptionPoco = new CompanyDescriptionPoco();
                companyDescriptionPoco.Company = companyProfilePoco.Id;
                companyDescriptionPoco.CompanyName = CompanyName;
                companyDescriptionPoco.CompanyDescription = CompanyDescription;
                companyProfilePoco.CompanyDescriptions.Add(companyDescriptionPoco);
                companyProfileLogic.Add( new [] {companyProfilePoco});
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

            CompanyProfilePoco companyProfilePoco = companyProfileLogic.Get(id.Value);

            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }

            var companyDescriptionPoco =
                companyDescriptionLogic.GetAll().Where(cd => cd.LanguageId.Trim() == "EN"
                                                             && cd.Company == companyProfilePoco.Id).FirstOrDefault();
            ViewBag.CompanyName = companyDescriptionPoco.CompanyName;
            ViewBag.ComapanyDescription = companyDescriptionPoco.CompanyDescription;
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,TimeStamp")]
            CompanyProfilePoco companyProfilePoco, string companyName, string companyDescription)
        {
            if (ModelState.IsValid)
            {
                var companyDescriptionPoco =
                    companyDescriptionLogic.GetAll().Where(cd => cd.LanguageId.Trim() == "EN" 
                                                                 && cd.Company == companyProfilePoco.Id).FirstOrDefault();
                companyDescriptionPoco.CompanyName = companyName;
                companyDescriptionPoco.CompanyDescription = companyDescription;
                companyProfileLogic.Update(new [] {companyProfilePoco});
                companyDescriptionLogic.Update(new [] {companyDescriptionPoco});
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

            CompanyProfilePoco companyProfilePoco = companyProfileLogic.Get(id.Value);
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
            CompanyProfilePoco companyProfilePoco = companyProfileLogic.Get(id);
            companyProfileLogic.Delete(new [] {companyProfilePoco});
            
            return RedirectToAction("Index");
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    public class System : ISystem
    {
        #region SystemCountryCode

        public void AddSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            var logic = new SystemCountryCodeLogic(repo);
            logic.Add(pocos);
        }

        public List<SystemCountryCodePoco> GetAllSystemCountryCode()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            var logic = new SystemCountryCodeLogic(repo);
            return logic.GetAll();
        }

        public SystemCountryCodePoco GetSingleSystemCountryCode(string code)
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            var logic = new SystemCountryCodeLogic(repo);
            return logic.Get(code);
        }

        public void RemoveSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            var logic = new SystemCountryCodeLogic(repo);
            logic.Delete(pocos);
        }

        public void UpdateSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            var logic = new SystemCountryCodeLogic(repo);
            logic.Update(pocos);
        }

        #endregion

        #region SystemLanguageCode

        public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);
            var logic = new SystemLanguageCodeLogic(repo);
            return logic.GetAll();
        }

        public SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id)
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);
            var logic = new SystemLanguageCodeLogic(repo);
            return logic.Get(Id);
        }

        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);
            var logic = new SystemLanguageCodeLogic(repo);
            logic.Delete(pocos);
        }

        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);
            var logic = new SystemLanguageCodeLogic(repo);
            logic.Update(pocos);
        }

        public void AddSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);
            var logic = new SystemLanguageCodeLogic(repo);
            logic.Add(pocos);
        }

        #endregion
    }
}

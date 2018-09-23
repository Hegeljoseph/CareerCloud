using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class CareerCloudMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CareerCloudMVCContext() : base("name=CareerCloudMVCContext")
        {
        }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.ApplicantJobApplicationPoco> ApplicantJobApplicationPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.ApplicantProfilePoco> ApplicantProfilePocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.ApplicantResumePoco> ApplicantResumePocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.ApplicantSkillPoco> ApplicantSkillPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.ApplicantWorkHistoryPoco> ApplicantWorkHistoryPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.CompanyDescriptionPoco> CompanyDescriptionPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.SystemLanguageCodePoco> SystemLanguageCodePocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.CompanyJobDescriptionPoco> CompanyJobDescriptionPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.CompanyJobEducationPoco> CompanyJobEducationPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.CompanyJobPoco> CompanyJobPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.CompanyJobSkillPoco> CompanyJobSkillPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.CompanyLocationPoco> CompanyLocationPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.SecurityLoginPoco> SecurityLoginPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.SecurityLoginsLogPoco> SecurityLoginsLogPocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.SecurityLoginsRolePoco> SecurityLoginsRolePocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.SecurityRolePoco> SecurityRolePocoes { get; set; }

        public System.Data.Entity.DbSet<CareerCloud.Pocos.SystemCountryCodePoco> SystemCountryCodePocoes { get; set; }
    }
}

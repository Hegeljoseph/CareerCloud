﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    [ServiceContract]

    public interface ICompany
    {
        #region CompanyDescription

        [OperationContract]
        void AddCompanyDescription(CompanyDescriptionPoco[] pocos);

        [OperationContract]
        List<CompanyDescriptionPoco> GetAllCompanyDescription();


        [OperationContract]
        CompanyDescriptionPoco GetSingleCompanyDescription(string Id);

        [OperationContract]
        void RemoveCompanyDescription(CompanyDescriptionPoco[] pocos);

        [OperationContract]
        void UpdateCompanyDescription(CompanyDescriptionPoco[] pocos);

        #endregion

        #region CompanyJobDescription

        [OperationContract]
        void AddCompanyJobDescription(CompanyJobDescriptionPoco[] pocos);

        [OperationContract]
        List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription();


        [OperationContract]
        CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id);

        [OperationContract]
        void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] pocos);

        [OperationContract]
        void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] pocos);

        #endregion

        #region CompanyJobEducation

        [OperationContract]
        void AddCompanyJobEducation(CompanyJobEducationPoco[] pocos);

        [OperationContract]
        List<CompanyJobEducationPoco> GetAllCompanyJobEducation();


        [OperationContract]
        CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id);

        [OperationContract]
        void RemoveCompanyJobEducation(CompanyJobEducationPoco[] pocos);

        [OperationContract]
        void UpdateCompanyJobEducation(CompanyJobEducationPoco[] pocos);

        #endregion

        #region CompanyJob

        [OperationContract]
        void AddCompanyJob(CompanyJobPoco[] pocos);

        [OperationContract]
        List<CompanyJobPoco> GetAllCompanyJob();


        [OperationContract]
        CompanyJobPoco GetSingleCompanyJob(string Id);

        [OperationContract]
        void RemoveCompanyJob(CompanyJobPoco[] pocos);

        [OperationContract]
        void UpdateCompanyJob(CompanyJobPoco[] pocos);

        #endregion

        #region CompanyJobSkill

        [OperationContract]
        void AddCompanyJobSkill(CompanyJobSkillPoco[] pocos);

        [OperationContract]
        List<CompanyJobSkillPoco> GetAllCompanyJobSkill();


        [OperationContract]
        CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id);

        [OperationContract]
        void RemoveCompanyJobSkill(CompanyJobSkillPoco[] pocos);

        [OperationContract]
        void UpdateCompanyJobSkill(CompanyJobSkillPoco[] pocos);

        #endregion

        #region CompanyLocation

        [OperationContract]
        void AddCompanyLocation(CompanyLocationPoco[] pocos);

        [OperationContract]
        List<CompanyLocationPoco> GetAllCompanyLocation();


        [OperationContract]
        CompanyLocationPoco GetSingleCompanyLocation(string Id);

        [OperationContract]
        void RemoveCompanyLocation(CompanyLocationPoco[] pocos);

        [OperationContract]
        void UpdateCompanyLocation(CompanyLocationPoco[] pocos);

        #endregion

        #region CompanyProfile

        [OperationContract]
        void AddCompanyProfile(CompanyProfilePoco[] pocos);

        [OperationContract]
        List<CompanyProfilePoco> GetAllCompanyProfile();


        [OperationContract]
        CompanyProfilePoco GetSingleCompanyProfile(string Id);

        [OperationContract]
        void RemoveCompanyProfile(CompanyProfilePoco[] pocos);

        [OperationContract]
        void UpdateCompanyProfile(CompanyProfilePoco[] pocos);

        #endregion
    }
}

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

    public interface ISecurity
    {
        #region SecurityLogin

        [OperationContract]
        void AddSecurityLogin(SecurityLoginPoco[] pocos);

        [OperationContract]
        List<SecurityLoginPoco> GetAllSecurityLogin();


        [OperationContract]
        SecurityLoginPoco GetSingleSecurityLogin(string Id);

        [OperationContract]
        void RemoveSecurityLogin(SecurityLoginPoco[] pocos);

        [OperationContract]
        void UpdateSecurityLogin(SecurityLoginPoco[] pocos);

        #endregion

        #region SecurityLoginsLog

        [OperationContract]
        void AddSecurityLoginsLog(SecurityLoginsLogPoco[] pocos);

        [OperationContract]
        List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog();


        [OperationContract]
        SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id);

        [OperationContract]
        void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] pocos);

        [OperationContract]
        void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] pocos);

        #endregion

        #region SecurityLoginsRole

        [OperationContract]
        void AddSecurityLoginsRole(SecurityLoginsRolePoco[] pocos);

        [OperationContract]
        List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole();


        [OperationContract]
        SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id);

        [OperationContract]
        void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] pocos);

        [OperationContract]
        void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] pocos);

        #endregion

        #region SecurityRole

        [OperationContract]
        void AddSecurityRole(SecurityRolePoco[] pocos);

        [OperationContract]
        List<SecurityRolePoco> GetAllSecurityRole();


        [OperationContract]
        SecurityRolePoco GetSingleSecurityRole(string Id);

        [OperationContract]
        void RemoveSecurityRole(SecurityRolePoco[] pocos);

        [OperationContract]
        void UpdateSecurityRole(SecurityRolePoco[] pocos);

        #endregion

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            _logic = new CompanyDescriptionLogic(repo);

        }

        [HttpGet]
        [Route("description/{id}")]
        [ResponseType(typeof(CompanyDescriptionPoco))]
        public IHttpActionResult GetCompanyDescription(Guid id)
        {
            CompanyDescriptionPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("description")]
        [ResponseType(typeof(CompanyDescriptionPoco))]
        public IHttpActionResult GetAllCompanyDescription()
        {
            List<CompanyDescriptionPoco> result = _logic.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("description")]
        public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("description")]
        public IHttpActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("description")]
        public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}

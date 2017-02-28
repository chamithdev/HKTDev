using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HKT.Data;
using HKT.Employee.Data;
using HKT.Employee.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HKT.Rating.WebApi.Controllers
{
    [Route("api/Employee")]
    public class EmployeeApiController : Controller
    {

        IRepository<Department, EmployeeContext> _deprepository;
        IRepository<Employee.Entity.Employee, EmployeeContext> _emprepository;
        IUnitOfWork<EmployeeContext> _unitOfWork;

        public EmployeeApiController(IRepository<Department, EmployeeContext> depRrepository, IRepository<Employee.Entity.Employee, EmployeeContext> empRrepository, IUnitOfWork<EmployeeContext> unitOfWork)
        {
            _deprepository = depRrepository;
            _unitOfWork = unitOfWork;
            _emprepository = empRrepository;
        }


        [HttpGet]
        [Route("departments")]
        public IEnumerable<Department> GetDepartments()
        {
            return new List<Department> { new Department { Id = 1, Name = "Customer Service", IsActive = true }, new Department { Id = 2, Name = "Logistics", IsActive = true } };
        }

        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

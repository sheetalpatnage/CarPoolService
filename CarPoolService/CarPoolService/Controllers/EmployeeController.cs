using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using CarPoolService.Models;
using System.Net.Http;
using System.Web.Http;
using System.Net;


namespace CarPoolService.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : ApiController
    {
        DataAccess da = new DataAccess();
        public EmployeeController()
        {
            
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return da.GetEmployees();
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var Emp = da.GetEmployee(new ObjectId(id));
            if (Emp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Id Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, Emp);
        }

        [HttpPost]
        public void AddEmployee([FromBody]Employee emp)       
        {
             da.AddEmployee(emp);
        }       

    }

}

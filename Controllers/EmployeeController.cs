using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstWidget.ITMS.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<EmployeeItem> Get(string ssn)
        {
            //In a real project, the employee will be retrieved from the database using Entity Framework.
            //Return a facade for now

            var employee = new EmployeeItem(
                ssn,
                "500 5th ave",
                "New York",
                "Yaron",
                "Habot",
                "NY"
            );

            string employeeValidMessage;
            bool validEmployeeData = employee.ValidateEmployeeData(out employeeValidMessage);
            if (!validEmployeeData) 
            {
                 throw new ArgumentException(employeeValidMessage);
            }

            return Enumerable.Range(1,1).Select(index => employee).ToArray();
        }

        [HttpPut]
        public string Put(EmployeeItem employeeItem)
        {
            string employeeValidMessage;
            bool validEmployeeData = employeeItem.ValidateEmployeeData(out employeeValidMessage);
            if (validEmployeeData) 
            {
                return "Employee information updated successfully";   
            }
            else
            {
                throw new ArgumentException(employeeValidMessage);
            }            
        }

        [HttpPost]
        public string Post(EmployeeItem employeeItem)
        {
            string employeeValidMessage;
            bool validEmployeeData = employeeItem.ValidateEmployeeData(out employeeValidMessage);
            if (validEmployeeData) 
            {
                return "Employee information created successfully";
            }
            else
            {
                throw new ArgumentException(employeeValidMessage);
            }            
        }

        [HttpDelete]
        public string Delete(string ssn)
        {
            //Verify that the specified ssn is valid and has excatly 9 digits
            if (EmployeeItem.ValidateSSN(ssn)) 
            {
                 throw new ArgumentException("Invalid ssn input. Expecting exactly 9 digits");
            }

            return "Employee information deleted successfully";
        }
    }
}

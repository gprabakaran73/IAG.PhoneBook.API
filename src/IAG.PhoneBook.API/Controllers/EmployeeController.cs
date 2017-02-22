using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IAG.PhoneBook.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace IAG.PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
 
        private phonebookContext _context;

        public EmployeeController(phonebookContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ObjectResult>Get()
        {
            var employee = await _context.Employee
                .ToListAsync();
            return Ok(employee);
        }

        [Route("getall")]
        [HttpGet]
        public async Task<ObjectResult>GetAll()
        {
            var employee = await _context.Employee
                .ToListAsync();
            return Ok(employee);
        }

        [Route("getbyname/{name}")]
        [HttpGet]
        public async Task<ObjectResult> GetEmployeeByName(string name)
        {

            var empsql = await _context.Employee.FromSql("select * from Employee where employee = '"+name+"'").ToListAsync();
            return Ok(empsql);
        }

        [Route("advancesearch/{name}")]
        [HttpGet]
        public async Task<IEnumerable<Employee>> AdvanceSearch(string name)
        {
            return await _context.Employee.FromSql("sp_GetAllEmployee").ToArrayAsync();
        }

        [Route("advancesearch1/{name}")]
        [HttpGet]
        public async Task<Employee> AdvanceSearch1(string name)
        {
            return await _context.Employee.FromSql("sp_GetAllEmployee1 @p0", name).FirstOrDefaultAsync();
        }

        //

        [Route("advancesearch2/{name}")]
        [HttpGet]
        public async Task<int> AdvanceSearch2(string name)
        {
            return await _context.Database.ExecuteSqlCommandAsync("sp_employee_INS @p0, @p1,@p2",
            parameters: new[] { "1002", "Prabakaran1002", "12" });
        }

    }
}

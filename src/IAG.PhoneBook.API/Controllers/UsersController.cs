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
    public class UsersController : Controller
    {

        private phonebookContext _context;

        public UsersController(phonebookContext context)
        {
            this._context = context;
        }

        //[Route("getbyempnum")]
        [HttpGet("{empnum}")]
        public async Task<IEnumerable<Users>>Get(string empnum)
        {
            return await _context.Users.FromSql("getByEmpNum @p0", empnum).ToArrayAsync();
        }

        [Route("search/{name}")]
        [HttpGet]
        public async Task<IEnumerable<Users>> Search(string name)
        {
            return await _context.Users.FromSql("sp_GetAllEmployee").ToArrayAsync();
        }
        //employeeNumber=&extensionNumber=&position=&safetyRole=&name=p&state=&function=&address=&=&=11&=0
        [Route("advancedSearch")]
        [HttpGet]
        public async Task<IEnumerable<Users>> AdvancedSearch(string employeeNumber,
            string extensionNumber, string position, string safetyRole, string name,
            string state, string function, string address, string level, string limit,string page)            
        {

            return await _context.Users.FromSql("sp_userAdvancedSearch @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p9",
                employeeNumber, extensionNumber, position, safetyRole, name, state, function, address, level, limit, page).ToArrayAsync();
        }

        [Route("findAllByManager")]
        [HttpGet]
        public async Task<IEnumerable<Users>> FindAllByManager(string mgrempnum,string excludeemp)
        {
            return await _context.Users.FromSql("findAllByManager @p0,@p1", mgrempnum, excludeemp).ToArrayAsync();
        }

        [Route("findEmployeesByManagerWithCount")]
        [HttpGet]
        public async Task<IEnumerable<Users>> FindEmployeesByManagerWithCount(string empnum)
        {
            return await _context.Users.FromSql("findEmployeesCountByManagerID @p0", empnum).ToArrayAsync();
        }

        [Route("getCurrentUser/{employeeNumber}")]
        [HttpGet]
        public async Task<IEnumerable<Users>> GetCurrentUser(string name)
        {
            return await _context.Users.FromSql("sp_GetAllEmployee").ToArrayAsync();
        }

        [Route("getUserSafetyRoles")]
        [HttpGet]
        public async Task<IEnumerable<Safetyroles>> GetUserSafetyRoles(string empnum)
        {
            return await _context.Safetyroles.FromSql("getUserSafetyRoles @p0", empnum).ToArrayAsync();
        }


    }
}

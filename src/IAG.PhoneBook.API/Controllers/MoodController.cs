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
    public class MoodController : Controller
    {
        private phonebookContext _context;

        public MoodController(phonebookContext context)
        {
            this._context = context;
        }

        [Route("getemployeehierarchy")]
        [HttpGet]
        public async Task<IEnumerable<Mood>>GetEmployeeHierarchy(string empid)
        {
            return await _context.Mood.FromSql("getEmployeeHierarchy @p0", empid).ToArrayAsync();
        }

        [Route("rollupbymanager")]
        [HttpGet]
        public async Task<IEnumerable<RollUp>> GetRollUpbyManager(string mgrid)
        {
            return await _context.RollUp.FromSql("RollUpbyManager @p0", mgrid).ToArrayAsync();
        }

        [Route("getemployeehierarchy")]
        [HttpGet]
        public async Task<IEnumerable<Mood>>GetAllEmployeeHierarchy(string empid)
        {
            return await _context.Mood.FromSql("getEmployeeHierarchy @p0", empid).ToArrayAsync();
        }
    }
}

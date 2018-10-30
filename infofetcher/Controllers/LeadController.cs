using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace infofetcher.Controllers
{
    [Route ("api/leads")]
    [ApiController]
    public class LeadController : ControllerBase 
    {
        private readonly rocket_devContext _context;

        public LeadController (rocket_devContext context) {
            _context = context;
            
        }

        [HttpGet]
        public ActionResult<List<Leads>> GetAll () {
            return _context.Leads.ToList ();
        }

        [HttpGet ("{id}", Name = "GetLeads")]
        public ActionResult<Leads> GetById (long id) {
            var item = _context.Leads.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }
    }
}
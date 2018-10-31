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
        private readonly mathieu_h_appContext _context;

        public LeadController (mathieu_h_appContext context) {
            _context = context;
            
        }

        // get all leads.
        [HttpGet]
        public ActionResult<List<Leads>> GetAll () {
            return _context.Leads.ToList ();
        }

        // get a specific lead with it's id.
        [HttpGet ("{id}", Name = "GetLeads")]
        public ActionResult<Leads> GetById (long id) {
            var item = _context.Leads.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }

        // Get all of the leads made in the last 30 days.
        [HttpGet ("latest", Name = "GetLatestLeads")]
        public ActionResult<List<Leads>> Get (long id, int Datetime) {
            var item = _context.Leads.Where(l=>(l.CreatedAt.Day + 30) >= Datetime);
                return item.ToList();
        }
    }
}
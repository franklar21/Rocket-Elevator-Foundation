using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace infofetcher.Controllers
{
    [Route ("api/columns")]
    [ApiController]
    public class Columncontroller : ControllerBase 
    {
        private readonly rocket_devContext _context;

        public Columncontroller (rocket_devContext context) {
            _context = context;
            
        }

        [HttpGet]
        public ActionResult<List<Columns>> GetAll () {
            return _context.Columns.ToList ();
        }

        [HttpGet ("{id}", Name = "GetColumns")]
        public ActionResult<Columns> GetById (long id) {
            var item = _context.Columns.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }
    }
}
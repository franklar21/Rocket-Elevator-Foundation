using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace infofetcher.Controllers {
    [Route ("api/columns")]
    [ApiController]
    public class Columncontroller : ControllerBase {
        private readonly mathieu_h_appContext _context;

        public Columncontroller (mathieu_h_appContext context) {
            _context = context;

        }

        [HttpGet]
        public ActionResult<List<Columns>> GetAll () {
            return _context.Columns.ToList ();
        }

        [HttpGet ("{id}", Name = "GetColumns")]
        public string GetById (string Status, long id) {
            var item = _context.Columns.Find (id);
            var _status = item.Status;
            if (item == null) {
                return "";
            }
            return _status;
        }

        [HttpPut ("{id}")]
        public IActionResult Update (long id, Columns item) {
            var Columns = _context.Columns.Find (id);
            if (Columns == null) {
                return NotFound ();
            }

            Columns.Status = item.Status;

            _context.Columns.Update (Columns);
            _context.SaveChanges ();
            return NoContent ();
        }
    }
}
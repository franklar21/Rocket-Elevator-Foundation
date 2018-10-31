using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace infofetcher.Controllers {
    [Route ("api/columns")]
    [ApiController]
    public class Columncontroller : ControllerBase {
        private readonly mathieu_h_appContext _context;

        public Columncontroller (mathieu_h_appContext context) {
            _context = context;

        }

        // get all colums.
        [HttpGet]
        public ActionResult<List<Columns>> GetAll () {
            return _context.Columns.ToList ();
        }

        // get the status of a specified column
        [HttpGet ("{id}", Name = "GetColumns")]
        public string GetById (string Status, long id) {
            var item = _context.Columns.Find (id);
            var _column = item.Id;
            var _status = item.Status;
            if (item == null) {
                return "Not Found";
            }
            return "The Column #" + _column + " is currently " + _status + ".";
        }

        // change the status of a specified column
        [HttpPut ("{id}", Name = "ChangeColumnStatus")]
        public string Update (long id, [FromBody] JObject body) {
            
            var column = _context.Columns.Find (id);
            if (column == null) {
                return "Enter a valid column id.";
            }
            
            var previous_status = column.Status; 
            var status = (string)body.SelectToken("status");
            if (status == "Active" || status == "Inactive" || status == "Alarm" || status == "Intervention"){
                column.Status = status;
                _context.Columns.Update (column);
                _context.SaveChanges ();
                return "The column #" + column.Id + " has changed status from " + previous_status + ", to " + status + ".";
            } else {
                return "Invalid status: Must be Active, Inactive, Alarm or Intervention";
            }
        }
    }
}
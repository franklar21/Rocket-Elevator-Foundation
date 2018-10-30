using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace infofetcher.Controllers {
    [Route ("api/elevators")]
    [ApiController]
    public class ElevatorController : ControllerBase {
        private readonly mathieu_h_appContext _context;

        public ElevatorController (mathieu_h_appContext context) {
            _context = context;
            
        }

        [HttpGet]
        public ActionResult<List<Elevators>> GetAll () {
            return _context.Elevators.ToList ();
        }

        [HttpGet ("{id}", Name = "GetElevators")]
        public ActionResult<Elevators> GetById (long id) {
            var item = _context.Elevators.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }

        [HttpPut ("{id}", Name = "ChangeElevatorStatus")]
        public string Update (long id, [FromBody] JObject body) {
            
            var elevator = _context.Elevators.Find (id);
            if (elevator == null) {
                return "Please enter a new status";
            }

            var newStatus = (string)body.SelectToken("status");
            if (newStatus == "Active"  || (newStatus == "Inactive" ) || (newStatus == "Alarm" ) || (newStatus == "Intervention")){
                var initialStatus = elevator.status;
                elevator.status = newStatus;
                _context.Elevators.Update (elevator);
                _context.SaveChanges ();
                return "The status of elevator #" + elevator.id + " successfuly changed from " + initialStatus + " to " + newStatus;
            } else {
                return "Invalid status: Must be Active, Inactive, Alarm or Intervention";
            }
        }
    }
}
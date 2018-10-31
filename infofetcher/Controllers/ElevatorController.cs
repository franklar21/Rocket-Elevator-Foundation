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
        
       


        // Get the current status of the specified elevator
        [HttpGet ("{id}", Name = "GetElevators")]
<<<<<<< HEAD
        public string GetById (string Status, long id) {
            var item = _context.Elevators.Find (id);
            var _status = item.Status;
            if (item == null) {
                return "";
            }
            return _status;
=======
        public string GetById (long id) {
            var item = _context.Elevators.Find (id);
            var _status = item.status;
            var _id =  _context.Elevators.Find (id).id;
            if (item == null) {
                return "Please enter a valid id.";
            }
            return "The elevator #" + _id + " is currently " + _status + ".";
        }

        // Get all elevators that are not currently active.
        [HttpGet ("status", Name = "GetNotActiveElevators")]
        public ActionResult<List<Elevators>> Get (string status) {
            var _result = _context.Elevators.Where(s=>s.status!="Operational");
            return _result.ToList();
        }
        
        [HttpPut ("{id}", Name = "PutElevatorStatus")]
        public string Update (long id, [FromBody] JObject body) {

            var elevator = _context.Elevators.Find (id);
            if (elevator == null) {
                return "Enter a valid elevator id.";
            }

            var previous_status = elevator.status;
            var status = (string) body.SelectToken ("status");
            if (status == "Active" || status == "Inactive" || status == "Alarm" || status == "Intervention") {
                elevator.status = status;
                _context.Elevators.Update (elevator);
                _context.SaveChanges ();
                return "The elevator #" + elevator.id + " has changed status from " + previous_status + ", to " + status + ".";
            } else {
                return "Invalid status: Must be Active, Inactive, Alarm or Intervention";
            }
>>>>>>> master
        }
    }
}
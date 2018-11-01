using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// just so i can push
namespace infofetcher.Controllers
{
    [Route ("api/batteries")]
    [ApiController]
    public class BatteryController : ControllerBase 
    {
        private readonly mathieu_h_appContext _context;

        public BatteryController (mathieu_h_appContext context) {
            _context = context;
            
        }

        // get all batteries
        [HttpGet]
        public ActionResult<List<Batteries>> GetAll () {
            return _context.Batteries.ToList ();
        }

        // Get the specified battery status
        [HttpGet ("{id:int}", Name = "GetBatteryStatus")]
        public string GetById (long id) {
            var batteryStatus = _context.Batteries.Find(id).Status;
            var _battery = _context.Batteries.Find(id).Id;
            if (batteryStatus == null) {
                return "Please enter a valid id";
            }
            return "The battery #" + _battery + " is currently " + batteryStatus + ".";
        }

        // Change the status of the specified battery
        [HttpPut ("{id}", Name = "ChangeBatteryStatus")]
        public string Update (long id, [FromBody] JObject body) {
            
            var battery = _context.Batteries.Find (id);
            if (battery == null) {
                return "Please enter a new status";
            }

            var newStatus = (string)body.SelectToken("status");
            if (newStatus == "Active"  || (newStatus == "Inactive" ) || (newStatus == "Alarm" ) || (newStatus == "Intervention")){
                var initialStatus = battery.Status;
                battery.Status = newStatus;
                _context.Batteries.Update (battery);
                _context.SaveChanges ();
                return "The status of battery #" + battery.Id + " successfuly changed from " + initialStatus + " to " + newStatus;
            } else {
                return "Invalid status: Must be Active, Inactive, Alarm or Intervention";
            }
        }
    }
}

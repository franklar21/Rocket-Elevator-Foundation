using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace infofetcher.Controllers {
    [Route ("api/elevators")]
    [ApiController]
    public class ElevatorController : ControllerBase {
        private readonly rocket_devContext _context;

        public ElevatorController (rocket_devContext context) {
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
    }
}
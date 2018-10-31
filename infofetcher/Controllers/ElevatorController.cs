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

        // Récupération d’une liste d’ascenseurs qui ne sont pas en opération au moment de la requête
        [HttpGet ("status", Name = "GetNotActiveElevators")]
        public ActionResult<List<Elevators>> Get (string status) {
            var _result = _context.Elevators.Where(s=>s.status!="Operational");
            return _result.ToList();
        }
        
    }
}
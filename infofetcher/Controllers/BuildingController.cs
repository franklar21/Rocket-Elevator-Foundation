using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace infofetcher.Controllers
{
    [Route ("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase 
    {
        private readonly mathieu_h_appContext _context;

        public BuildingController (mathieu_h_appContext context) {
            _context = context;
            
        }

        [HttpGet]
        public ActionResult<List<Buildings>> GetAll () {
            return _context.Buildings.ToList ();
        }

        [HttpGet ("{id}", Name = "GetBuildings")]
        public ActionResult<Buildings> GetById (long id) {
            var item = _context.Buildings.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }

        // Récupération d’une liste de buildings qui contiennent au moins une batterie, une colonne ou un ascenseur requérant une intervention

        [HttpGet ("status", Name = "GetBuildingsList")]
        public ActionResult<List<Buildings>> Get (string status) {
            var _result = _context.Buildings.Where(s=>s.Buildings.id == s.Columns.building_id)
                                .Include(s=>s.Batteries.Where(s=>s.status == "Intervention"))
                                .Include(s=>s.Columns.Where(s=>s.status == "Intervention"))
                                .Include(s=>s.Elevators.Where(s=>s.status == "Intervention"))
                                .FirstOrDefault();
            return _result.ToList();
        } 

        //2e version 

        [HttpGet ("status", Name = "GetBuildingsList")]
      public ActionResult<List<Buildings>> Get (string status, Batteries battery) {
          var _result = _context.Buildings.Where(s=>s.Id == battery.BuildingId)
                              .Include(s=>s.Batteries.Where(s=>s.status == "Intervention"))
                              .Include(s=>s.Columns.Where(s=>s.status == "Intervention"))
                              .Include(s=>s.Elevators.Where(s=>s.status == "Intervention"))
                              .FirstOrDefault();
          return _result.ToList();
      }
        
    }
}


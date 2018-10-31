using System;
using System.Collections.Generic;
using System.Linq;
using infofetcher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Pomelo.EntityFrameworkCore.MySql;

namespace infofetcher.Controllers {
    [Route ("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase {
        private readonly mathieu_h_appContext _context;

        public BuildingController (mathieu_h_appContext context) {
            _context = context;

        }
        // get all buildings
        [HttpGet]
        public ActionResult<List<Buildings>> GetAll () {
            return _context.Buildings.ToList ();
        }

        // getting a specific building with it's id
        [HttpGet ("{id}", Name = "GetBuildings")]
        public ActionResult<Buildings> GetById (long id) {
            var item = _context.Buildings.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }
        public string WhyThough () {
            var i_dont_know = "I dont't know what I'm doing anymore.";
            return i_dont_know;
        }
        // getting a list of buildings that have either a battery, column or elevator that needs intervention
        [HttpGet ("status", Name = "GetBuildingsList")]
        public ActionResult<List<Buildings>> Get () {
            var buildings = _context.Buildings
                .Include (s => s.Batteries)
                .ThenInclude (s => s.Columns)
                .ThenInclude (s => s.Elevators);

            var found_buildings = new List<Buildings> ();
            foreach (var building in buildings) {
                var found = false;
                foreach (var battery in building.Batteries) {
                    if (battery.Status == "intervention") {
                        found = true;
                    }
                    if (found) {
                        break;
                    }
                    foreach (var column in battery.Columns) {
                        if (column.Status == "intervention") {
                            found = true;
                        }
                        if (found) {
                            break;
                        }
                        foreach (var elevator in column.Elevators) {
                            if (elevator.status == "intervention") {
                                found = true;
                            }
                            if (found) {
                                break;
                            }
                        }
                    }
                }
                if (found) {
                    found_buildings.Add (building);
                }
            }
            return found_buildings;
        }
    }
}
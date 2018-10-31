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

        [HttpGet]
        public ActionResult<List<Batteries>> GetAll () {
            return _context.Batteries.ToList ();
        }

        [HttpGet ("{id:int}", Name = "GetBatteryStatus")]
        public string GetById (long id) {
            var batteryStatus = _context.Batteries.Find(id).Status;
            
            if (batteryStatus == null) {
                return "";
            }
            return batteryStatus;
        }
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



// [Route("{id:int}/details")]
// [ResponseType(typeof(BookDetailDto))]
// public async Task<IHttpActionResult> GetBookDetail(int id)
// {
//     var book = await (from b in db.Books.Include(b => b.Author)
//                 where b.BookId == id
//                 select new BookDetailDto
//                 {
//                     Title = b.Title,
//                     Genre = b.Genre,
//                     PublishDate = b.PublishDate,
//                     Price = b.Price,
//                     Description = b.Description,
//                     Author = b.Author.Name
//                 }).FirstOrDefaultAsync();
// }
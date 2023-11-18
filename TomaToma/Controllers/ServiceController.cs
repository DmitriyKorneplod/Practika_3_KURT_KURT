using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomaToma.Models;

namespace TomaToma.Controllers
{
    [ApiController]
    [Route("/service")]
    public class ServiceController : Controller
    {
       
        
            [HttpGet]
            public IActionResult GetAll()
            {
                var db = new SssrContext();
                return Ok(db.Services);
            }
            [HttpGet]
            [Route("{id}")]
            public IActionResult GetById(int id)
            {
                var db = new SssrContext();
                var serv = db.Services.SingleOrDefault(s => s.Id == id);
                if (serv == null)
                    return NotFound();
                return Ok(serv);
            }
            [HttpPost]
            public IActionResult Add(Service service)
            {
                var db = new SssrContext();
                db.Services.Add(service);
                db.SaveChanges();
                return Ok(service);
            }
            [HttpPut]
            public IActionResult Edit(Service servi)
            {
                var db = new SssrContext();
                db.Services.Update(servi);
                db.SaveChanges();
                return Ok(servi);
            }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new SssrContext();
                var serv = db.Services.SingleOrDefault(s => s.Id == id);
                if (serv == null)
                    return NotFound();
                db.Services.Remove(serv);
                db.SaveChanges();
                return Ok(serv);
            }
    }
}

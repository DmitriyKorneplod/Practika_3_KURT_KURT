using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomaToma.Models;

namespace TomaToma.Controllers
{
    [ApiController]
    [Route("/services")]
    public class ServicesController : Controller
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
                var serv = db.Services.SingleOrDefault(s => s.id == id);
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
            public IActionResult Edit(Service service)
            {
                var db = new SssrContext();
                db.Services.Update(service);
                db.SaveChanges();
                return Ok(service);
            }
            [HttpDelete]
            [Route("{id}")]
            public IActionResult Delete(int id)
            {
                var db = new SssrContext();
                var servi = db.Services.SingleOrDefault(s => s.id == id);
                if (servi == null)
                    return NotFound();
                db.Services.Remove(servi);
                db.SaveChanges();
                return Ok(servi);
            }
        
    }
}


﻿using Microsoft.AspNetCore.Http;
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
                var clo = db.Clients.SingleOrDefault(s => s.Id == id);
                if (clo == null)
                    return NotFound();
                return Ok(clo);
            }
            [HttpPost]
            public IActionResult Add(Client client)
            {
                var db = new SssrContext();
                db.Clients.Add(client);
                db.SaveChanges();
                return Ok(client);
            }
            [HttpPut]
            public IActionResult Edit(Client clis)
            {
                var db = new SssrContext();
                db.Clients.Update(clis);
                db.SaveChanges();
                return Ok(clis);
            }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new SssrContext();
                var client = db.Clients.SingleOrDefault(s => s.Id == id);
                if (client == null)
                    return NotFound();
                return Ok(client);
            }
        
    }
}


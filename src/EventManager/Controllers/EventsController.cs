using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using EventManager.Models;
using EventManager.Repository;

namespace EventManager.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly EventRepository _eventRepository;

        public EventsController(IConfiguration configuration)
        {
            _eventRepository = new EventRepository(configuration);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _eventRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _eventRepository.FindByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Event e)
        {
            _eventRepository.Add(e);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event e)
        {
            _eventRepository.Update(e);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _eventRepository.Remove(id);
        }


        public ActionResult Index()
        {
            ViewBag.Title = "test";

            return View();
        }
    }
}

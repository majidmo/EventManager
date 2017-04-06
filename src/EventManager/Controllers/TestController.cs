using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using EventManager.Models;
using EventManager.Repository;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly EventRepository _repository;

        public TestController(IConfiguration configuration)
        {
            _repository = new EventRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(_repository.FindAll());
        }
        
    }
}

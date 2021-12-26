
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _locationService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _locationService.GetById(id);
            return Ok(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromBody] Location location)
        {
            var result = _locationService.Add(location);
            return Ok(result);
        }

        [HttpPost("createOrUpdate")]
        public IActionResult CreateOrUpdate([FromBody] Location location)
        {
            var result = _locationService.CreateOrUpdate(location);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Location location)
        {
            var result = _locationService.Update(location);
            return Ok(result);
        }

    }
}


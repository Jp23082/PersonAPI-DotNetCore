using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : ControllerBase
    {

        private readonly IPersonPhoneService personPhoneService;

        public PersonPhoneController(IPersonPhoneService personPhoneService)
        {
            this.personPhoneService = personPhoneService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.personPhoneService.Get());
        }

        [HttpPost]
        public IActionResult Post(PersonPhoneViewModel personPhoneViewModel) 
        {
            return Ok(this.personPhoneService.Post(personPhoneViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.personPhoneService.GetByBusinessEntityID(id));
        }

        [HttpPut]
        public IActionResult Put(PersonPhoneViewModel personPhoneViewModel)
        {
            return Ok(this.personPhoneService.Put(personPhoneViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.personPhoneService.Delete(id));
        }
    }
}

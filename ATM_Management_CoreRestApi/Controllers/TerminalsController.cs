using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_Management_CoreRestApi.Data.Interface;
using ATM_Management_CoreRestApi.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM_Management_CoreRestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Terminals")]
    public class TerminalsController : Controller
    {

        private readonly ITerminalRepository _TermRepo;

        public TerminalsController(ITerminalRepository repository)
        {
            _TermRepo = repository;
        }


        // GET: api/Terminals
        [HttpGet]
        public IEnumerable<Terminal> Get()
        {
            var terminals = _TermRepo.GetAll();
            return terminals;          
        }

        // GET: api/Terminals/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {           
            var term = _TermRepo.GetById(id);
            if (term == null)
            {
                return NotFound();
            }
            return Ok(term);
        }
        
        // POST: api/Terminals
         [HttpPost]
        public IActionResult Post([FromBody]Terminal value)
        {
            int res = _TermRepo.Create(value);
            if (res != 0)
            {
                return Ok(res);
            }
            return NotFound();
        }

        // PUT: api/Terminals/5
        [HttpPut]
        public IActionResult Put([FromBody]Terminal value)
        {
            int res = _TermRepo.Update(value);
            if (res != 0)
            {
                return Ok(res);
            }
            return NotFound();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete([FromBody]Terminal value)
        {
            int res = _TermRepo.Delete(value);
            if (res != 0)
            {
                return Ok();
            }
            return NotFound();
        }

     
    }
}

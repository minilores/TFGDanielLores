using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaslavNijinskyOrgApp.Data;
using VaslavNijinskyOrgApp.Models;

namespace VaslavNijinskyOrgApp.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController] 
    public class ChoreographiesController : Controller
    {
        private readonly EventDb _context;

        public ChoreographiesController(EventDb context)
        {
            _context = context;
        }


        // Filter by name, category and school


        [HttpGet]
        public ActionResult<IEnumerable<Choreography>> GetAll()
        {
            if (_context.Choreography.Any())
            {
                return Ok(_context.Choreography);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Choreography> GetById(int id)
        {
            if (_context.Choreography.Any(c => c.Id == id))
            {
                return Ok(_context.Choreography.SingleOrDefault(c => c.Id == id));
            }
            else
            {
                return NotFound($"The database don´t have a choreography with the Id {id}");
            }
        }

        [HttpGet("{name}")]
        public ActionResult<Choreography> GetByName(string name)
        {
            if (_context.Choreography.Any(c => c.Name == name))
            {
                return Ok(_context.Choreography.Any(c => c.Name == name));
            }
            else
            {
                return NotFound($"The database don´t have a choreography with the name {name}");
            }
        }
        [HttpGet("{category}")]
        public ActionResult<Choreography> GetByCategory(string category)
        {
            if (_context.Choreography.Any(c => c.Category == category))
            {
                return Ok(_context.Choreography.Any(c => c.Category == category));
            }
            else
            {
                return NotFound($"The database don´t have a choreography with the category {category}");
            }
        }

        [HttpGet("{schoolName}")]
        public ActionResult<Choreography> GetBySchoolName(string schoolName)
        {
            if (_context.Choreography.Any(c => c.SchoolName == schoolName))
            {
                return Ok(_context.Choreography.Any(c => c.SchoolName == schoolName));
            }
            else
            {
                return NotFound($"The database don´t have a choreography with the schoolName {schoolName}");
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] Choreography newChoreography)
        {
            if (!_context.Choreography.Any(c => c.Id == newChoreography.Id))
            {
                _context.Choreography.Add(newChoreography);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"The database already has a choreography with the Id {newChoreography.Id}");
            }
        }

        [HttpPut]
        public ActionResult Edit(int id, [FromBody] Choreography newChoreography)
        {
            var ChoreographyToUpdate = _context.Choreography.FirstOrDefault(c => c.Id.Equals(id));

            ChoreographyToUpdate.Name = newChoreography.Name;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {

            if (_context.Choreography.Any(c => c.Id == id))
            {
                var ChoreographyToDelete = _context.Choreography.Single(c => c.Id == id);
                _context.Choreography.Remove(ChoreographyToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"The database don´t have a choreography with the id {id}");
            }
        }
    }
}

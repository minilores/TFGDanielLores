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
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : Controller
    {
        private readonly EventDb _context;

        public SchoolsController(EventDb context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<School>> GetAll()
        {
            if (_context.School.Any())
            {
                return Ok(_context.School);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<School> GetById(int id)
        {
            if (_context.School.Any(s => s.Id == id))
            {
                return Ok(_context.School.SingleOrDefault(s => s.Id == id));
            }
            else
            {
                return NotFound($"The database don´t have a school with the Id {id}");
            }
        }
        [HttpGet("Name/{name}")]
        public ActionResult<School> GetByName(string name)
        {
            if (_context.School.Any(s => s.Name == name))
            {
                return Ok(_context.School.SingleOrDefault(s => s.Name.ToLower() == name.ToLower()));
            }
            else
            {
                return NotFound($"The database don´t have a school with the name {name}");
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] School newSchool)
        {
            if (!_context.School.Any(s => s.Id == newSchool.Id))
            {
                _context.School.Add(newSchool);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"The database already has a school with the Id {newSchool.Id}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] School newSchool)
        {
            var SchoolToUpdate = _context.School.FirstOrDefault(c => c.Id.Equals(id));

            SchoolToUpdate.Name = newSchool.Name;

            _context.SaveChanges();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)  
        {

            if (_context.School.Any(s => s.Id == id))
            {
                var SchoolToDelete = _context.School.Single(s => s.Id == id);
                _context.School.Remove(SchoolToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"The database don´t have a school with the id {id}");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TypeController(MyDbContext context) {
        _context = context;
        }


        [HttpGet]
        public IActionResult GetAll() { 
            var types = _context.Types.ToList();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public IActionResult GetTypeById(int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.type_id == id);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }

        [HttpPost]
        public IActionResult CreateType(TypeModel model) {
            var type = new Type
            {
                type_name = model.type_name
            };
            _context.Add(type);
            _context.SaveChanges();
            return Ok(type);
        }

        [HttpPut("{id}")]
        public IActionResult EditTypeById(int id, TypeModel model)
        {
            var type = _context.Types.SingleOrDefault(t => t.type_id == id);
            if (type == null)
            {
                return NotFound();
            }
            type.type_name = model.type_name;
            _context.SaveChanges();
            return Ok(type);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTypeById(int id, TypeModel model)
        {
            var type = _context.Types.SingleOrDefault(t => t.type_id == id);
            if (type == null)
            {
                return NotFound();
            }
            _context.Remove(type);
            _context.SaveChanges();
            return Ok();
        }

    }
}

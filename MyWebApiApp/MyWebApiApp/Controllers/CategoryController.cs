using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public categoryController(MyDbContext context) {
        _context = context;
        }


        [HttpGet]
        public IActionResult GetAll() { 
            var categorys = _context.Categories.ToList();
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public IActionResult GetcategoryById(int id)
        {
            var category = _context.Categories.SingleOrDefault(t => t.category_id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Createcategory(CategoryModel model) {
            var category = new Category
            {
                category_name = model.category_name
            };
            _context.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult EditcategoryById(int id, CategoryModel model)
        {
            var category = _context.Categories.SingleOrDefault(t => t.category_id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.category_name = model.category_name;
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id, CategoryModel model)
        {
            var category = _context.Categories.SingleOrDefault(t => t.category_id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}

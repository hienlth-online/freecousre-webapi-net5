using API.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TransactionController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() { 
            var userid = User.GetUserId();
            return Ok(_context.Transactions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactionById(Guid id) {
            var userid = User.GetUserId();
            var trans = _context.Transactions.SingleOrDefault(u =>
            u.transaction_id == id);
            if (trans != null)
            {
                return Ok(trans);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateTransaction(TransactionModel model) {

            var userid = User.GetUserId();
                var new_trans = new Transaction
                {
                    transaction_id = Guid.NewGuid(),
                    amount = model.amount,
                    description = model.description,
                    created_at = DateTime.Now,
                    category_id = model.category_id,
                    type_id = model.type_id,
                };
                _context.Add(new_trans);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = new_trans
                });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(Guid id, TransactionModel model) {
            var userid = User.GetUserId();
            var trans = _context.Transactions.SingleOrDefault(u =>
            u.transaction_id == id);
            if (trans != null)
            {
                trans.amount = model.amount;
                trans.description = model.description;
                trans.created_at = DateTime.Now;
                trans.category_id = model.category_id;
                trans.type_id = model.type_id;
                _context.SaveChanges();
                return Ok(trans);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(Guid id)
        {
            var userid = User.GetUserId();
            var trans = _context.Transactions.SingleOrDefault(u => u.transaction_id == id);
            if (trans != null)
            {
                _context.Transactions.Remove(trans);
                _context.SaveChanges(); 
                return Ok();
            }
            return NotFound();
        }
    }
}

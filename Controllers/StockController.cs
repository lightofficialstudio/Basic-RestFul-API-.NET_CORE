using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // DEPADENCY INJECTION (DI)
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stock = _context.Stocks.ToList();

            return Ok(ApiResponseHelper.Success(stock));
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);
            var stock2 = _context.Stocks.FirstOrDefaultAsync(item => item.Id == id);


            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
    }
}
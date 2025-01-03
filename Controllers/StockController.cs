using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Helpers;
using api.Mappers;
using api.Dtos.Stock;

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
            var stock = _context.Stocks.ToList()
            .Select(s => s.ToStockDto());

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

            var result = stock.ToStockDto();

            return Ok(ApiResponseHelper.Success(result));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            try
            {
                var stockModel = stockDto.ToStockFromCreateDTO();
                _context.Stocks.Add(stockModel);
                _context.SaveChanges();

                var result = ApiResponseHelper.Success(stockModel.ToStockDto());

                // return CreatedAtAction(nameof(GetById), new
                // {
                //     id = stockModel.Id
                // }, result);

                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message
                });
            }
        }
    }
}
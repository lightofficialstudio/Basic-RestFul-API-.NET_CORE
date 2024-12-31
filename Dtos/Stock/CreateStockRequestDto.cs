using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required(ErrorMessage = "Symbol is required.")]
        public string Symbol { get; set; } = string.Empty;

        [Required(ErrorMessage = "CompanyName is required.")]
        public string CompanyName { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Purchase must be greater than 0.")]
        public decimal Pruchase { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "LastDiv must be non-negative.")]
        public decimal LastDiv { get; set; }

        [Required(ErrorMessage = "Industry is required.")]
        public string Industry { get; set; } = string.Empty;

        [Range(1, long.MaxValue, ErrorMessage = "MarketCap must be greater than 0.")]
        public long MarketCap { get; set; }
    }
}
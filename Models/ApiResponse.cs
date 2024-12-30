using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public required T Data { get; set; }
        public required string MessageTh { get; set; }
        public required string MessageEn { get; set; }
    }
}
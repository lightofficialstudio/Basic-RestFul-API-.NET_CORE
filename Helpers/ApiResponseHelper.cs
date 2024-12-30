using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers
{
    public class ApiResponseHelper
    {
        public static ApiResponse<T> Success<T>(T data, string messageTh = "ดำเนินการสำเร็จ", string messageEn = "Operation successful")
        {
            return new ApiResponse<T>
            {
                Status = 200,
                Data = data,
                MessageTh = messageTh,
                MessageEn = messageEn,
                Meta = new MetaData
                {
                    TotalData = data is IEnumerable<object> collection ? collection.Count() : 1
                },
            };
        }
    }
}
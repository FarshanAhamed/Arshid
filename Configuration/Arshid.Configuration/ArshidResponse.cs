using System;
using System.Collections.Generic;
using System.Text;

namespace Arshid.Configuration
{
    public class ArshidResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }


        public static ArshidResponse<T> SetResponse(string status, string message, T data)
        {
            ArshidResponse<T> response = new ArshidResponse<T>() { Status = status, Message = message, Data = data };
            return response;
        }
    }
}

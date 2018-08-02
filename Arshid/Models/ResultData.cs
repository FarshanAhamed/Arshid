using System;

namespace Arshid.Web.Models
{
    public class ResultData<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

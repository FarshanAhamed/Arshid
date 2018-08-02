﻿using System;

namespace Arshid.Data
{
    public class ResultData<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

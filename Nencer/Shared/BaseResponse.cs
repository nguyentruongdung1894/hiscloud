﻿namespace Nencer.Shared
{
    public class BaseResponse<T>
    {
        public string Status { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

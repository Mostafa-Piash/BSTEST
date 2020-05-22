using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace API.Data.ResponseModel
{
    public class CommonApiResponse
    {
        public static CommonApiResponse Create(HttpStatusCode statusCode, object result = null)
        {
            return new CommonApiResponse(statusCode, result);
        }

        public int StatusCode { get; set; }
        public string Status { get; set; }
        public object Result { get; set; }
       
        protected CommonApiResponse(HttpStatusCode statusCode, object result = null)
        {
            StatusCode = (int)statusCode;
            Status =$"{(int)statusCode} {(statusCode).ToString()}";
            Result = result;
        }
    }
}

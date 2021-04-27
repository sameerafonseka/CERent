using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.Results;

namespace CERent.Core.Lib.Api
{
    public class BaseResponse<T> where T : class
    {
        public BaseResponse(T data)
        {
            if (data is Exception)
            {
                Status = "error";
            }
            else
            {
                this.Data = data;
            }
        }

        public string Status { get; set; }

        public T Data { get; set; }
    }
}

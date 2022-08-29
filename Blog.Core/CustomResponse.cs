using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public class CustomResponse<T>
    {
        public T Data { get; set; }
        public List<String> Errors { get; set; }
        public int StatusCode { get; private set; }


        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { StatusCode = statusCode };
        }

        public static CustomResponse<T> Success(T Data, int statusCode)
        {
            return new CustomResponse<T>() { Data = Data, StatusCode = statusCode };
        }
        public static CustomResponse<T> Fail(string error, int statusCode)
        {
            return new CustomResponse<T>() { Errors = new List<string> { error }, StatusCode = statusCode };
        }

        public static CustomResponse<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomResponse<T>() { Errors = errors, StatusCode = statusCode };
        }
    }
}

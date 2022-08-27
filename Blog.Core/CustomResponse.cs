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

        public static CustomResponse<T> Success()
        {
            return new CustomResponse<T>();
        }

        public static CustomResponse<T> Success(T Data)
        {
            return new CustomResponse<T>() { Data = Data};
        }
        public static CustomResponse<T> Fail(string error)
        {
            return new CustomResponse<T>() { Errors = new List<string> { error } };
        }

        public static CustomResponse<T> Fail(List<string> errors)
        {
            return new CustomResponse<T>() { Errors = errors };
        }
    }
}

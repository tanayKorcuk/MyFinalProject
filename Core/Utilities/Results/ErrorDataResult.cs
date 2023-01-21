using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> :DataResult<T>
    {
        public ErrorDataResult(T data, bool success, string message) : base(data, false,message)
        {
            Data = data;
        }
        public ErrorDataResult(T data, bool success) : base(data,false)
        {
            Data = data;
        }
        public T Data { get; }
        public ErrorDataResult(T data) : base(default, false) { }
        public ErrorDataResult(string x) : base(default, false) { }
    }

    
}

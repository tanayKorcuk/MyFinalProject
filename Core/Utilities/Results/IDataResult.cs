using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult//Aynı zamanda t türünde bir data barıncak içnde
    {

      public  T Data { get; }
    
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //private bool v1;>>bunlara ihtiyacımız yok.
        //private string v2;

        public Result(bool success, string message):this(success)
        {

            Message = message;//constructor içerisinde set edebiliyoruz.
            Success = success;
            //   this.v1 = v1;
          
         //this.v2 = v2;
        }
        public Result(bool success)// sadece tru döndürülen bir yapı için
        {
            Success = Success;
        }
        public bool Success { get; }

        public string Message { get; }
         
    }
}

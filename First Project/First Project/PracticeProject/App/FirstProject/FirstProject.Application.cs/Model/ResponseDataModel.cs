using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstProject.Application.cs.Model
{
    public class ResponseModel<T>
    {//krti jao 
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }//s

        public static ResponseModel<T> SuccessResponse(T data, string message = " Request Completed successfully")
        {

            return new ResponseModel<T>
            {
                Success=true,
                Data = data,
                Message = message
            };
        }

        public static ResponseModel<T> FailureResponse(string message)
        {
            return new ResponseModel<T>
            {
                Success=false,
                Message = message,
                Data=default

            };
        }

       
    }
    }

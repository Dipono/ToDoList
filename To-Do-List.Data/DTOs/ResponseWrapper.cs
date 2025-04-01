using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Data.DTOs
{
    public class ResponseWrapper
    {
        public ResponseWrapper() 
        { 
            Message = string.Empty;
            Success = false;
        }    
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object ?Results { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Results
{
    public class BaseResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public int ErrorCode { get; set; } = 0;
    }
}

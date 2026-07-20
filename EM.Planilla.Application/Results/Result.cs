using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Application.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public int ErrorCode { get; set; }
        public string? Message { get; }
        public IReadOnlyCollection<string> Errors { get; }
        public Result()
        {
            
        }
        protected internal Result(bool isSuccess, string? message, int errorCode = 0, IEnumerable<string>? errors = null)
        {
            IsSuccess = isSuccess;
            ErrorCode = errorCode;
            Message = message;
            Errors = errors?.ToList() ?? new List<string>();
        }

        public static Result Success() => new(true, "Process Successfully");
        public static Result Success(string message) => new(true, message);
        public static Result Failure(string error) => new(false, error);
        public static Result Failure(string error, int errorCode) => new(false, error, errorCode);
        public static Result Failure(IEnumerable<string> errors) => new(false, "Process Failed", 0, errors);
    }

    public class Result<T> : Result
    {
        public T? Data { get; }
        protected internal Result(bool isSuccess, string? message, T? data = default, IEnumerable<string>? errors = null)
            : base(isSuccess, message, 0, errors)
        {
            Data = data;
        }
        public static Result<T> Success(T data) => new(true, "Process Successfully", data);
        public static new Result<T> Failure(string error) => new(false, error);      
        public static new Result<T> Failure(IEnumerable<string> errors) => new(false, "Process Failed", default, errors);
    }
}

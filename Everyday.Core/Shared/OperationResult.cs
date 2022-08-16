using Everyday.Core.Interfaces;

namespace Everyday.Core.Shared
{
    public class OperationResult : IConveyOperationResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public OperationResult()
        {
            Result = this;
        }
        public OperationResult(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Result = this;
        }
        public OperationResult(int statusCode, string message, object result)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }
    }
}

using Newtonsoft.Json;

namespace Everyday.Core.Interfaces
{
    /// <summary>
    /// Special wrapper used to expand HttpResponseMessage content in some cases.
    /// </summary>
    public interface IConveyOperationResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        /// <summary>
        /// A factory providing new instances of IConveyOperationResult compatible objects.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IConveyOperationResult Create(int statusCode, string message, object result = null)
        {
            return new OperationResult(statusCode, message, result);
        }

        /// <summary>
        /// A factory providing new instances of IConveyOperationResult compatible objects - positive case only, with no message.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IConveyOperationResult Create(object result)
        {
            return new OperationResult(0, string.Empty, result);
        }

        private sealed class OperationResult : IConveyOperationResult
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public object Result { get; set; }

            internal OperationResult()
            {
                Result = this;
            }
            internal OperationResult(int statusCode, string message)
            {
                StatusCode = statusCode;
                Message = message;
                Result = this;
            }
            internal OperationResult(int statusCode, string message, object result)
            {
                StatusCode = statusCode;
                Message = message;
                Result = result;
            }
        }
    }
}

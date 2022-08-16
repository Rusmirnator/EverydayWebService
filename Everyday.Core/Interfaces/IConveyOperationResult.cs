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
    }
}

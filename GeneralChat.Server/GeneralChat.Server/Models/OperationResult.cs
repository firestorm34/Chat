namespace GeneralChat.Server.Models
{
    public class OperationResult
    {
        public OperationResult(OperationStatus status)
        {
            this.Status = status;
        }
        public OperationResult(OperationStatus status, string message)
        {
            this.Status = status;
            this.Exception = new Exception(message);
        }
        public OperationResult(OperationStatus status, Exception exception)
        {
            this.Status = status;
            this.Exception = exception;
        }

        public OperationStatus Status { get; private set; } = OperationStatus.Successed;
        public Exception? Exception { get; private set; } = null;
        public string Message { get; private  set; }
    }

    public enum OperationStatus
    {
        Successed,
        Failed
    }
    public class OperationException: Exception
    {
        public OperationException(): base()
        {
               
        }
        public OperationException(string message): base(message)
        {
        }
        public OperationException(Exception exception): base()
        {

        }

        public OperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

namespace GeneralChat.Server.Models
{
    public class OperationResult
    {
        public OperationStatus Status { get; private set; } = OperationStatus.Successed;
        public Exception? Exception { get; private set; } = null;
        //public string? Message { get; private  set; }
        public OperationResult(OperationStatus status)
        {
            Status = status;
        }
        //public OperationResult(OperationStatus status, string message)
        //{
        //    this.Status = status;
        //    this.Exception = new Exception(message);
        //}
        public OperationResult(OperationStatus status, Exception exception)
        {
            Status = status;
            Exception = exception;
        }

    }


    public enum OperationStatus
    {
        Successed,
        Failed
    }
    

    #region In processing...

    //public class OperationException: Exception
    // {
    //     public OperationException(): base()
    //     {
               
    //     }
    //     public OperationException(string message): base(message)
    //     {
    //     }
    //     public OperationException(Exception exception): base()
    //     {

    //     }

    //     public OperationException(string? message, Exception? innerException) : base(message, innerException)
    //     {
    //     }
    // }


    //public class OperationValueResult<T>: IOperationResult where T : class
    //{
    //    public OperationStatus Status { get; private set; } = OperationStatus.Successed;
    //    public Exception? Exception { get; private set; } = null;
    //    public T? Object { get; set; }
    //    public OperationValueResult(OperationStatus status)
    //    {
    //        Status = status;
    //    }

    //    public OperationValueResult(OperationStatus status, T objectInstance)
    //    {
    //        Status = status;
    //        Object = objectInstance;
    //    }

    //    public OperationValueResult(OperationStatus status, Exception exception)
    //    {
    //        Status = status;
    //        Exception = exception;

    //    }
    //}

    //public interface IOperationResult
    //{
    //}

    #endregion
}

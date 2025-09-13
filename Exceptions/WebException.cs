namespace WebStockManagement.Exceptions;
public class WebException : Exception
{
    public string Message { get; set; }
    public string ErrorCode { get; set; }


    public WebException(string errorCode, string message)
    {
        Message = message;
        ErrorCode = errorCode;
    }
}
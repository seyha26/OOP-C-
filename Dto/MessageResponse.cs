namespace WebStockManagement.Dto;

public class MessageResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string ErrorCode { get; set; }
    public Object Data { get; set; }

    public MessageResponse()
    {

    }

    public MessageResponse(Object data, string message, string errorCode, bool isSuccess)
    {
        Data = data;
        Message = message;
        ErrorCode = errorCode;
        IsSuccess = isSuccess;
    }
}
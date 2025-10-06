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

    public void GetDataSuccess(Object data)
    {
        IsSuccess = true;
        Data = data;
        Message = "Get Data Success";
        ErrorCode = "SUC-0000";
    }

    public void SetMessageError(string message)
    {
        IsSuccess = false;
        Data = null;
        Message = message;
        ErrorCode = "ERR-0001";
    }

    public void SetMessageInternalServerError(string message)
    {
        IsSuccess = false;
        Data = null;
        Message = message;
        ErrorCode = "ERR-0002";
    }
}
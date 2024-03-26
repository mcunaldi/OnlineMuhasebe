using Newtonsoft.Json;

namespace OnlineMuhasebeServer.WebAPI.Middleware;

public class ErrorResult : ErrorStatusCode
{
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ErrorStatusCode
{
    public int StatusCode { get; set; }
}

public class ValidationErrorsDetails : ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; }
}

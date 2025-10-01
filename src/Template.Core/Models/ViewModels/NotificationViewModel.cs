using System.Net;

namespace Template.Core.Models.ViewModels;

public class NotificationViewModel(string message, HttpStatusCode statusCode)
{
    public string Message { get; } = message;
    public HttpStatusCode StatusCode { get; } = statusCode;
}

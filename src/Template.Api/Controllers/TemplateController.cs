using Microsoft.AspNetCore.Mvc;
using Template.Core.Interfaces.Notifications;

namespace Template.Api.Controllers;

public class TemplateController(INotifier notifier) : MainController(notifier)
{
    [HttpGet("hello-world")]
    public IActionResult HelloWorld()
    {
        return PersonalizedResponse(Ok("Hello World!"));
    }
}

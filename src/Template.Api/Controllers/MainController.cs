using Microsoft.AspNetCore.Mvc;
using Template.Core.Interfaces.Notifications;
using Template.Core.Models.ViewModels;

namespace Template.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(DefaultResponseViewModel), 500)]
public class MainController(INotifier notifier) : ControllerBase
{
    protected readonly INotifier _notifier = notifier;

    protected ActionResult PersonalizedResponse(ActionResult actionResult)
    {
        if (IsValidOperation())
            return actionResult;

        var notifications = _notifier.GetNotifications();

        return new JsonResult(new DefaultResponseViewModel(notifications.Select(n => n.Message)))
        {
            StatusCode = (int)notifications[0].StatusCode,
        };
    }

    private bool IsValidOperation() => !_notifier.HasAnyNotification();
}

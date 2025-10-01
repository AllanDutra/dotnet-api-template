using System.Net;
using Template.Core.Models.ViewModels;

namespace Template.Core.Interfaces.Notifications;

public interface INotifier
{
    void ClearNotifications();
    bool HasAnyNotification();
    List<NotificationViewModel> GetNotifications();
    void Handle(string message, HttpStatusCode statusCode);
}

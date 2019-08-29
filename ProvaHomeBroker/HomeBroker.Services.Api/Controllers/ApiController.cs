using System.Linq;
using HomeBroker.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace HomeBroker.Services.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {

        private readonly NotificationContext _notifications;

        protected ApiController(NotificationContext notifications)
        {
            _notifications = notifications;
        }

        protected bool IsValidOperation() =>
             (!_notifications.HasNotifications);

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.Notifications
            });
        }

    }
}

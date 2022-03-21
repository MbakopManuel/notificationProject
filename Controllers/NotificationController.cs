

using Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace NotificationProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController 
    {
        private readonly NotificationHub _notificationHub;
        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationController(
            IHubContext<NotificationHub> hubContext,
            IConfiguration configuration
        )
        {
            _notificationHub = new NotificationHub(hubContext);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpPost]
        public async Task<ActionResult<Notification>> Create([FromBody] Notification viewModel)
        {

           try
            {
                // send notification
                await _notificationHub.SendNotification(viewModel.ReferenceId, viewModel);

                return viewModel;
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

    }
}
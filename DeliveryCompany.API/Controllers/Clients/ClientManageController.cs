using DeliveryCompany.API.Common;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Results;
using DeliveryCompany.Application.Interfaces.OutServices.Clients.Clients;
using DeliveryCompany.Contracts.ClientOrders.Clients.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.Clients;

[ApiController]
[Authorize(Roles = "Client")]
[Route("manageClient/client")]
public class ClientManageController : ControllerBase
{
    private readonly IClientManage _clientManage;

    public ClientManageController(IClientManage clientManage)
    {
        _clientManage = clientManage;
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(string password)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        try
        {
            await Task.Run(() => _clientManage.changePassword(clientId, password));
        }
        catch (ArgumentException e)
        {
            return BadRequest();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }


        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost("restore-password")]
    public async Task<IActionResult> CreateNewOrder(string email, string password, string secretCode)
    {
        try
        {
            await Task.Run(() => _clientManage.restorePassword(email, password, secretCode));
        }
        catch (ArgumentException e)
        {
            return BadRequest();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }


        return Ok();
    }
}
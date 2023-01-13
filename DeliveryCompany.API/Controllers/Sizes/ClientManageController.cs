using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SizeRequest = DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients.Requests.SizeRequest;

namespace DeliveryCompany.API.Controllers.Sizes;

[ApiController]
[Authorize(Roles = "Client")]
[Route("manageSize/client")]
public class ClientManageController : ControllerBase
{
    private readonly IClientManage _manageSize;

    public ClientManageController(IClientManage manageSize)
    {
        _manageSize = manageSize;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllSizes()
    {
        SizeListResult result = await Task.Run(() => _manageSize.GetAllSizes());
        return Ok(result);
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetSize(SizeRequest request)
    {
        SizeResult result = await Task.Run(() => _manageSize.GetSize(request));
        return Ok(result);
    }
}
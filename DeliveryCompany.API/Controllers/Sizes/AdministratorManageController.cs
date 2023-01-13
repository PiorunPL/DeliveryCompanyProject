using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.Sizes;

[ApiController]
[Authorize(Roles = "Administrator")]
[Route("manageSize/administrator")]
public class AdministratorManageController : ControllerBase
{
    private readonly IAdministratorManage _manageSize;

    public AdministratorManageController(IAdministratorManage manageSize)
    {
        _manageSize = manageSize;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateSize(CreateSizeRequest request)
    {
        SizeResult result = await Task.Run(() => _manageSize.Create(request));
        return Ok(result);
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
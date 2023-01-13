using DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators;
using DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.Couriers;

[ApiController]
[Authorize(Roles = "Administrator")]
[Route("couriersManage/administrator")]
public class AdministratorManageController : ControllerBase
{
    private readonly IAdministratorManage _manageCourier;

    public AdministratorManageController(IAdministratorManage manageCourier)
    {
        _manageCourier = manageCourier;
    }

    [HttpGet("get-unassigned")]
    public async Task<IActionResult> GetUnassignedCouriers()
    {
        CourierListResult result = await Task.Run(() => _manageCourier.GetUnassignedCouriers());
        return Ok(result);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllCouriers()
    {
        CourierListResult result = await Task.Run(() => _manageCourier.GetCouriers());
        return Ok(result);
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetCourier(CourierRequest request)
    {
        CourierResult result = await Task.Run(() => _manageCourier.GetCourier(request));
        return Ok(result);
    }
}
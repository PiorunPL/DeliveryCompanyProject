using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrators;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrators.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrators.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.CourierOrders;

[ApiController]
[Authorize(Roles = "Administrator")]
[Route("manageCourierOrder/administrator")]
public class AdministratorManageController : ControllerBase
{
    private readonly IAdministratorManage _manageCourierOrders;

    public AdministratorManageController(IAdministratorManage manageCourierOrders)
    {
        _manageCourierOrders = manageCourierOrders;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        OrderResult result = await Task.Run(() => _manageCourierOrders.Create(request));
        return Ok(result);
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelOrder(OrderRequest request)
    {
        OrderResult result = await Task.Run(() => _manageCourierOrders.Cancel(request));
        return Ok(result);
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetOrder([FromQuery]OrderRequest request)
    {
        OrderResult result = await Task.Run(() => _manageCourierOrders.Get(request));
        return Ok(result);
    }

    [HttpGet("get-missing")]
    public async Task<IActionResult> GetMissingOrders([FromQuery]ClientOrderRequest request)
    {
        OrderListResult result = await Task.Run(() => _manageCourierOrders.GetMissingForClientOrder(request));
        return Ok(result);
    }
    
}
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrators;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrators.Results;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrators.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.ClientOrders;

[ApiController]
[Authorize(Roles = "Administrator")]
[Route("manageClientOrder/administrator")]
public class AdministratorManageController : ControllerBase
{
    private readonly IAdministratorManage _manageClientOrders;

    public AdministratorManageController(IAdministratorManage manageClientOrders)
    {
        _manageClientOrders = manageClientOrders;
    }

    // TODO: Przemyśleć czy zamienić POST na PUT
    [HttpPost("accept")]
    public async Task<IActionResult> CreateNewOrder(OrderRequest request)
    {
        OrderResult result = await Task.Run(() => _manageClientOrders.AcceptOrder(request));
        return Ok(result);
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitOrderRoute(OrderRequest request)
    {
        OrderResult result = await Task.Run(() => _manageClientOrders.SubmitOrderRoute(request));
        return Ok(result);
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelOrder(OrderRequest request)
    {
        OrderResult result = await Task.Run(() => _manageClientOrders.CancelOrder(request));
        return Ok(result);
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetOrder([FromQuery]OrderRequest request)
    {
        OrderResult result = await Task.Run(() => _manageClientOrders.GetOrder(request));
        return Ok(result);
    }

    [HttpGet("get-all-active")]
    public async Task<IActionResult> GetAllActiveOrders()
    {
        OrderListResult result = await Task.Run(() => _manageClientOrders.GetAllActiveOrders());
        return Ok(result);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllOrders()
    {
        OrderListResult result = await Task.Run(() => _manageClientOrders.GetAllOrders());
        return Ok(result);
    }
}
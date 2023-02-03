// using DeliveryCompany.API.Common;
// using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Couriers;
// using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Couriers.Requests;
// using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Couriers.Results;
// using DeliveryCompany.Contracts.CourierOrders.Couriers.Requests;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace DeliveryCompany.API.Controllers.CourierOrders;
//
// [ApiController]
// [Authorize(Roles = "Courier")]
// [Route("manageCourierOrder/courier")]
// public class CourierManageController : ControllerBase
// {
//     private readonly ICourierManage _manageCourierOrders;
//
//     public CourierManageController(ICourierManage manageCourierOrders)
//     {
//         _manageCourierOrders = manageCourierOrders;
//     }
//
//     [HttpPost("accept")]
//     public async Task<IActionResult> AcceptOrder(OrderApiRequest apiRequest)
//     {
//         Guid courierId = CommonMethods.GetPersonsGuid(this.HttpContext);
//
//         OrderRequest request = new OrderRequest(apiRequest.orderId, courierId);
//         OrderResult result = await Task.Run(() => _manageCourierOrders.Accept(request));
//
//         return Ok(result);
//     }
//
//     [HttpPost("resign")]
//     public async Task<IActionResult> ResignOrder(OrderApiRequest apiRequest)
//     {
//         Guid courierId = CommonMethods.GetPersonsGuid(this.HttpContext);
//
//         OrderRequest request = new OrderRequest(apiRequest.orderId, courierId);
//         OrderResult result = await Task.Run(() => _manageCourierOrders.Resign(request));
//
//         return Ok(result);
//     }
//
//     [HttpPost("pickUp")]
//     public async Task<IActionResult> PickUpOrder(OrderApiRequest apiRequest)
//     {
//         Guid courierId = CommonMethods.GetPersonsGuid(this.HttpContext);
//
//         OrderRequest request = new OrderRequest(apiRequest.orderId, courierId);
//         OrderResult result = await Task.Run(() => _manageCourierOrders.PickUpPackage(request));
//
//         return Ok(result);
//     }
//     
//     [HttpPost("deliver")]
//     public async Task<IActionResult> DeliverOrder(OrderApiRequest apiRequest)
//     {
//         Guid courierId = CommonMethods.GetPersonsGuid(this.HttpContext);
//
//         OrderRequest request = new OrderRequest(apiRequest.orderId, courierId);
//         OrderResult result = await Task.Run(() => _manageCourierOrders.SetAsDelivered(request));
//
//         return Ok(result);
//     }
//     
//     [HttpGet("get-available")]
//     public async Task<IActionResult> GetAvailableOrders()
//     {
//         Guid courierId = CommonMethods.GetPersonsGuid(this.HttpContext);
//
//         CourierRequest request = new CourierRequest(courierId);
//         OrderListResult result = await Task.Run(() => _manageCourierOrders.GetAvailableForCourier(request));
//
//         return Ok(result);
//     }
//     
//     [HttpGet("get-all")]
//     public async Task<IActionResult> GetAllByCourier()
//     {
//         Guid courierId = CommonMethods.GetPersonsGuid(this.HttpContext);
//
//         CourierRequest request = new CourierRequest(courierId);
//         OrderListResult result = await Task.Run(() => _manageCourierOrders.GetAllByCourier(request));
//
//         return Ok(result);
//     }
// }

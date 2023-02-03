// using DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrators;
// using DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrators.Requests;
// using DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrators.Results;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace DeliveryCompany.API.Controllers.Facilities;
//
// [ApiController]
// [Authorize(Roles = "Administrator")]
// [Route("manageFacilities/administrator")]
// public class AdministratorManageController : ControllerBase
// {
//     private readonly IAdministratorManage _manageFacilities;
//
//
//     public AdministratorManageController(IAdministratorManage manageFacilities)
//     {
//         _manageFacilities = manageFacilities;
//     }
//
//     [HttpPost("assign")]
//     public async Task<IActionResult> AssignCourier(AssignRequest request)
//     {
//         AssignResult result = await Task.Run(() => _manageFacilities.AssignCourier(request));
//         return Ok(result);
//     }
//
//     [HttpPost("unassign")]
//     public async Task<IActionResult> UnassignCourier(CourierRequest request)
//     {
//         AssignResult result = await Task.Run(() => _manageFacilities.UnassignCourier(request));
//         return Ok(result);
//     }
//     [HttpPost("create")]
//     public async Task<IActionResult> CreateFacility(CreateFacilityRequest request)
//     {
//         FacilityResult result = await Task.Run(() => _manageFacilities.CreateFacility(request));
//         return Ok(result);
//     }
//     
//     [HttpPost("close")]
//     public async Task<IActionResult> CloseFacility(FacilityRequest request)
//     {
//         FacilityResult result = await Task.Run(() => _manageFacilities.CloseFacility(request));
//         return Ok(result);
//     }
//     
//     [HttpPost("open")]
//     public async Task<IActionResult> OpenFacility(FacilityRequest request)
//     {
//         FacilityResult result = await Task.Run(() => _manageFacilities.OpenFacility(request));
//         return Ok(result);
//     }
//     
//     [HttpGet("get")]
//     public async Task<IActionResult> GetFacility([FromQuery]FacilityRequest request)
//     {
//         FacilityResult result = await Task.Run(() => _manageFacilities.GetFacility(request));
//         return Ok(result);
//     }
//     
//     [HttpGet("get-all")]
//     public async Task<IActionResult> GetAllFacilities()
//     {
//         FacilityListResult result = await Task.Run(() => _manageFacilities.GetAllFacilities());
//         return Ok(result);
//     }
// }
using DeliveryCompany.API.Common;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Results;
using DeliveryCompany.Contracts.ClientOrders.Clients.Requests;
using DeliveryCompany.Contracts.ClientOrders.Clients.Responses;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.ClientOrders;

[ApiController]
[Authorize(Roles = "Client")]
[Route("manageClientOrder/client")]
public class ClientManageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IClientManage _manageClientOrders;

    public ClientManageController(IMapper mapper, IClientManage manageClientOrders)
    {
        _mapper = mapper;
        _manageClientOrders = manageClientOrders;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateNewOrder(ClientOrderCreateApiRequest apiRequest)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        var request = _mapper.Map<CreateRequest>((apiRequest, clientId));
        ClientOrderResult result = await _manageClientOrders.CreateNewClientOrderAsync(request);

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelOrder(ClientOrderCancelApiRequest apiRequest)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        var request = _mapper.Map<CancelRequest>((apiRequest, clientId));
        ClientOrderResult result = await Task.Run(() => _manageClientOrders.CancelClientOrder(request));

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("get")]
    public async Task<IActionResult> GetOrder(ClientOrderClientGetApiRequest apiRequest)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        var request = _mapper.Map<GetRequest>((apiRequest, clientId));
        ClientOrderResult result = await Task.Run((() => _manageClientOrders.GetOrder(request)));

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }

    [HttpPost("get-image")]
    public async Task<IActionResult> GetImage(GetImageRequest request)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);
 
        string? imageBase;
        try
        {
            imageBase = _manageClientOrders.GetImage(clientId, request.orderId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }

        return Ok(imageBase);
    }

    public record GetImageRequest(Guid orderId);


    [HttpPost("get-shared")]
    public async Task<IActionResult> GetSharedOrder(ClientOrderClientGetApiRequest apiRequest)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        var request = _mapper.Map<GetRequest>((apiRequest, clientId));
        ClientOrderResult result = await Task.Run((() => _manageClientOrders.GetSharedOrder(request)));

        return Ok(_mapper.Map<ClientOrderAPIClientResponse>(result));
    }


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllOrders()
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        GetAllResult result = await Task.Run((() => _manageClientOrders.GetOrders(clientId)));

        var target = Map(result); //TODO: Good to Change Map method to Mapster Invocation

        return Ok(target);
        // return Ok(_mapper.Map<ClientGetAllApiResponse>(result));
    }

    [HttpGet("get-all-shared")]
    public async Task<IActionResult> GetAllSharedOrders()
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        GetAllResult result = await Task.Run((() => _manageClientOrders.GetOrdersShared(clientId)));

        var target = Map(result); //TODO: Good to Change Map method to Mapster Invocation

        return Ok(target);
    }

    [HttpPost("share-order")]
    public async Task<IActionResult> ShareOrder(RequestTemp request)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);
        try
        {
            await Task.Run((() => _manageClientOrders.ShareOrder(clientId, request.orderId, request.email)));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return Ok();
    }

    public record RequestTemp(Guid orderId, string email);

    [HttpPost("image")]
    public async Task<IActionResult> SetImageToOrder([FromForm] Guid orderId, IFormFile file)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        try
        {
            await Task.Run(() => _manageClientOrders.SetImage(file, clientId, orderId));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return Ok();
    }


    public record ImageRequest([FromForm] string OrderId, [FromForm] IFormFile File);

    private ClientGetAllApiResponse Map(GetAllResult result)
    {
        var response = new ClientGetAllApiResponse(new List<ClientOrderDto>());

        foreach (var item in result.Orders)
        {
            var dto = new ClientOrderDto(
                item.Id.Value,
                item.Name,
                item.Status.ToString()
            );
            response.list.Add(dto);
        }

        return response;
    }
}
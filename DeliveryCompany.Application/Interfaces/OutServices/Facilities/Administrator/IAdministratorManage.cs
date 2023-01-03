namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator;

public interface IAdministratorManage
{
    public Results.AssignResult AssignCourier(Requests.AssignRequest request);
    public Results.AssignResult UnassignCourier(Requests.CourierRequest request);
    public Results.FacilityResult CreateFacility(Requests.CreateFacilityRequest request);
    public Results.FacilityResult CloseFacility(Requests.FacilityRequest request);
    public Results.FacilityResult OpenFacility(Requests.FacilityRequest request);
    public Results.FacilityResult GetFacility(Requests.FacilityRequest request);
    public Results.FacilitiesResult GetAllFacilities();

}
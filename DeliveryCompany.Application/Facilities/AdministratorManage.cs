using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator;
using DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator.Results;
using DeliveryCompany.Domain.Couriers;
using DeliveryCompany.Domain.Facilities;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.Facilities;

public class AdministratorManage : IAdministratorManage
{
    private readonly ICourierRepository _courierRepository;
    private readonly IFacilityRepository _facilityRepository;
    private readonly ILogger<AdministratorManage> _logger;

    public AdministratorManage(ICourierRepository courierRepository, IFacilityRepository facilityRepository, ILogger<AdministratorManage> logger)
    {
        _courierRepository = courierRepository;
        _facilityRepository = facilityRepository;
        _logger = logger;
    }

    public AssignResult AssignCourier(AssignRequest request)
    {
        // 1. Check if courier exists
        Courier? courier = _courierRepository.GetCourierById(request.CourierId);
        if (courier is null)
            throw new ArgumentException("Courier with given ID does not exist!");
        
        // 2. Check if courier is already assigned
        Facility? oldFacility = _facilityRepository.GetByCourierId(request.CourierId);
        if (oldFacility is not null)
            throw new ApplicationException("Courier is already assigned to Facility!");
        
        // 3. Check if Facility exists
        Facility? facility = _facilityRepository.GetById(request.FacilityId);
        if (facility is null)
            throw new ArgumentException("Facility with given ID does not exist!");
        
        // 3.1 Check if Facility is closed
        if (facility.Status is FacilityStatus.Closed)
            throw new ApplicationException("Courier can't be assigned to closed facility");
        
        // 4. Assign Courier to Facility
        facility.CouriersId.Add(courier.Id.Value);
        
        // 5. Update Repository
        _facilityRepository.Update(facility);

        return new AssignResult(courier, facility);
    }

    public AssignResult UnassignCourier(CourierRequest request)
    {
        // 1. Check if courier exists
        Courier? courier = _courierRepository.GetCourierById(request.CourierId);
        if (courier is null)
            throw new ArgumentException("Courier with given ID does not exist!");
        
        // 2. Check if courier is assigned
        Facility? facility = _facilityRepository.GetByCourierId(request.CourierId);
        if (facility is null)
            throw new ApplicationException("Courier is already not assigned to any facility");
        
        // 3. Unassign courier from current Facility
        facility.CouriersId.Remove(courier.Id.Value);
        
        // 4. Update Repository
        _facilityRepository.Update(facility);

        return new AssignResult(courier, facility);
    }

    public FacilityResult CreateFacility(CreateFacilityRequest request)
    {
        // 1. Validate facility name
        //TODO: Implement this step - Validation
        
        // 2. Validate facility address
        //TODO: Implement this step - Validation
        
        // 3. Create new Facility
        Facility facility = Facility.Create(request.Address,request.Name);
        
        // 4. Add to Repository
        _facilityRepository.Add(facility);

        return new FacilityResult(facility);
    }

    public FacilityResult CloseFacility(FacilityRequest request)
    {
        // 1. Check if Facility Exists
        Facility? facility = _facilityRepository.GetById(request.FacilityId);
        if (facility is null)
            throw new ArgumentException("Facility with given ID does not exist!");
        
        // 2. Check if Facility is not already Closed
        if (facility.Status.Equals(FacilityStatus.Closed))
            throw new ApplicationException("Facility is already closed!");
        
        // 3. Close Facility
        facility.Status = FacilityStatus.Closed;
        
        // 4. Change Status of all Couriers from that Facility as Unassigned
        facility.CouriersId.Clear();
        
        // 5. Update Repository
        _facilityRepository.Update(facility);

        return new FacilityResult(facility);
    }

    public FacilityResult OpenFacility(FacilityRequest request)
    {
        // 1. Check if Facility Exists
        Facility? facility = _facilityRepository.GetById(request.FacilityId);
        if (facility is null)
            throw new ArgumentException("Facility with given ID does not exist!");
        
        // 2. Check if Facility is already Opened
        if (facility.Status.Equals(FacilityStatus.Open))
            throw new ApplicationException("Facility is already Opened");
        
        // 3. Open Facility
        facility.Status = FacilityStatus.Open;
        
        // 4. Update Repository
        _facilityRepository.Update(facility);

        return new FacilityResult(facility);
    }

    public FacilityResult GetFacility(FacilityRequest request)
    {
        // 1. Check if Facility exists
        Facility? facility = _facilityRepository.GetById(request.FacilityId);
        if (facility is null)
            throw new ArgumentException("Facility with given ID does not exist!");
        
        // 2. Return Facility
        return new FacilityResult(facility);
    }

    public FacilitiesResult GetAllFacilities()
    {
        //1. Return all facilities
        return new FacilitiesResult(_facilityRepository.GetFacilities());
    }
}
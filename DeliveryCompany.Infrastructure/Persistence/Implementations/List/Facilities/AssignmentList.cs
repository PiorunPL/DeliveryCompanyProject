using DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.List.Facilities;

public class AssignmentList : IAssignment
{
    private List<AssignmentDto> _assignmentDb = new List<AssignmentDto>();

    public List<Guid> GetAllCouriersByFacilityId(Guid facilityId)
    {
        List<AssignmentDto> filteredList = _assignmentDb.FindAll(dto => dto.FacilityId == facilityId.ToString());
        List<Guid> listOfCouriers = new List<Guid>();
        foreach (var assign in filteredList)
        {
            Guid courierId = Guid.Parse(assign.CourierId);
            listOfCouriers.Add(courierId);
        }

        return listOfCouriers;
    }

    public string? GetFacilityIdByCourierId(Guid courierId)
    {
        AssignmentDto? foundDto = _assignmentDb.Find(dto => dto.CourierId == courierId.ToString());
        if (foundDto is null)
            return null;
        return foundDto.FacilityId;
    }

    public void UpdateAssignment(List<Guid> couriersId, Guid facilityId)
    {
        foreach (var courierId in couriersId)
        {
            AssignmentDto? foundDto = _assignmentDb.Find(assign => assign.CourierId == courierId.ToString());
            if (foundDto is not null)
                _assignmentDb.Remove(foundDto);
            AssignmentDto newDto = new AssignmentDto(courierId.ToString(), facilityId.ToString());
            _assignmentDb.Add(newDto);
        }

        throw new NotImplementedException();
    }

    private class AssignmentDto
    {
        public AssignmentDto(string courierId, string facilityId)
        {
            CourierId = courierId;
            FacilityId = facilityId;
        }

        public string CourierId { get; set; }
        public string FacilityId { get; set; }
    }
}
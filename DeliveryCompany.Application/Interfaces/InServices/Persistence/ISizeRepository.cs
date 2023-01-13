using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Interfaces.InServices.Persistence;

public interface ISizeRepository
{
    public void Add(Size size);
    public void Update(Size size);
    public List<Size> GetAll();
    public Size? GetById(Guid id);
    public void Remove(Size size);
    public void RemoveById(Guid id);
}
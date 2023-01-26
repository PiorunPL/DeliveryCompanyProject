using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public class SharedOrderDto
{
    public string ClientOrderDtoId { get; set; }
    public string ClientId { get; set; }
    
    public virtual ClientOrderDto ClientOrderDto { get; set; }
    public virtual ClientDto ClientDto { get; set; }
}
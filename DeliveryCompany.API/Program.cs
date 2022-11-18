using DeliveryCompany.API;
using DeliveryCompany.Application;
using DeliveryCompany.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

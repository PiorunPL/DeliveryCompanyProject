namespace DeliveryCompany.Contracts.Authentication.Workers;

public record WorkerRegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime DateBirth,
    string Address
);
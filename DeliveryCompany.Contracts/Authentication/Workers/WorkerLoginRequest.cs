namespace DeliveryCompany.Contracts.Authentication.Workers;

public record WorkerLoginRequest(
    string Email,
    string Password
);
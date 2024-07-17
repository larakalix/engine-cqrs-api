namespace CleanArchitecture.Contracts.Customers;

public record CustomerResponse(Guid Id, string Name, DateTimeOffset DateTime, bool IsDismissed);

using CleanArchitecture.Domain.Customers;

using Throw;

namespace CleanArchitecture.Application.Customers.Common;

public record CustomerResult(Guid Id, string Name)
{
    public static CustomerResult FromUser(Customer customer)
    {
        return new CustomerResult(customer.Id, customer.Name);
    }
}
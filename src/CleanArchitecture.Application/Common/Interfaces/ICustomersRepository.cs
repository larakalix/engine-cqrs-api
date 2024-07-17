using CleanArchitecture.Domain.Customers;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICustomersRepository
{
    Task AddAsync(Customer customer, CancellationToken cancellationToken);
    Task<Customer?> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);
    Task<List<Customer>> ListAsync(CancellationToken cancellationToken);
    Task RemoveAsync(Customer customer, CancellationToken cancellationToken);
    Task RemoveRangeAsync(List<Customer> customers, CancellationToken cancellationToken);
    Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
}
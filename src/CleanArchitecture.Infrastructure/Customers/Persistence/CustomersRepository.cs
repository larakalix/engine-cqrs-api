using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Infrastructure.Common;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Customers.Persistence;

public class CustomersRepository(AppDbContext _dbContext) : ICustomersRepository
{
    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(customer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Customer?> GetByIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await _dbContext.Customers.FindAsync(customerId, cancellationToken);
    }

    public async Task<List<Customer>> ListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Customers.ToListAsync(cancellationToken);
    }

    public async Task RemoveAsync(Customer customer, CancellationToken cancellationToken)
    {
        _dbContext.Remove(customer);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveRangeAsync(List<Customer> customers, CancellationToken cancellationToken)
    {
        _dbContext.RemoveRange(customers, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        _dbContext.Update(customer);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

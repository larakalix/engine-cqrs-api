using CleanArchitecture.Application.Common.Security.Permissions;
using CleanArchitecture.Application.Common.Security.Policies;
using CleanArchitecture.Application.Common.Security.Request;
using CleanArchitecture.Domain.Customers;

using ErrorOr;

namespace CleanArchitecture.Application.Reminders.Queries.ListCustomers;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record ListCustomersQuery(Guid UserId) : IAuthorizeableRequest<ErrorOr<List<Customer>>>;
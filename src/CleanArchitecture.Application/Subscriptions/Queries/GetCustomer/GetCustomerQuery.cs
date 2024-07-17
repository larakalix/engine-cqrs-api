using CleanArchitecture.Application.Common.Security.Permissions;
using CleanArchitecture.Application.Common.Security.Policies;
using CleanArchitecture.Application.Common.Security.Request;
using CleanArchitecture.Application.Customers.Common;

using ErrorOr;

namespace CleanArchitecture.Application.Subscriptions.Queries.GetCustomer;

[Authorize(Permissions = Permission.Subscription.Get, Policies = Policy.SelfOrAdmin)]
public record GetCustomerQuery(Guid UserId) : IAuthorizeableRequest<ErrorOr<CustomerResult>>;
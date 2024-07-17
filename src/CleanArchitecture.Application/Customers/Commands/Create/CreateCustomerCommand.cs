using CleanArchitecture.Application.Common.Security.Permissions;
using CleanArchitecture.Application.Common.Security.Policies;
using CleanArchitecture.Application.Common.Security.Request;
using CleanArchitecture.Application.Customers.Common;

using ErrorOr;

namespace CleanArchitecture.Application.Subscriptions.Commands.CreateCustomer;

[Authorize(Permissions = Permission.Subscription.Create, Policies = Policy.SelfOrAdmin)]
public record CreateCustomerCommand(
    Guid UserId,
    string Name)
    : IAuthorizeableRequest<ErrorOr<CustomerResult>>;
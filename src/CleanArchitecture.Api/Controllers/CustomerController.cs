using CleanArchitecture.Application.Customers.Common;
using CleanArchitecture.Application.Reminders.Queries.ListCustomers;
using CleanArchitecture.Application.Subscriptions.Commands.CreateCustomer;
using CleanArchitecture.Application.Subscriptions.Queries.GetCustomer;
using CleanArchitecture.Contracts.Customers;
using CleanArchitecture.Domain.Customers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("{tenantId:guid}/customer")]
public class CustomerController(ISender _mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(Guid tenantId, CreateCustomerRequest request)
    {
        var command = new CreateCustomerCommand(tenantId, request.Name);

        var result = await _mediator.Send(command);

        return result.Match(
            subscription => CreatedAtAction(
                actionName: nameof(GetCustomer),
                routeValues: new { TenantId = tenantId },
                value: ToDto(subscription)),
            Problem);
    }

    [HttpGet("{customerId:guid}")]
    public async Task<IActionResult> GetCustomer(Guid customerId)
    {
        var query = new GetCustomerQuery(customerId);

        var result = await _mediator.Send(query);

        return result.Match(
            customer => Ok(ToDto(customer)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListCustomers(Guid tenantId)
    {
        var query = new ListCustomersQuery(tenantId);

        var result = await _mediator.Send(query);

        return result.Match(
            customers => Ok(customers.ConvertAll(ToDto)),
            Problem);
    }

    private CustomerResponse ToDto(Customer customer) => new(customer.Id, customer.Name, customer.DateTime, customer.IsDismissed);

    private CustomerResponse ToDto(CustomerResult customerResult) => new(customerResult.Id, customerResult.Name, DateTime: new DateTimeOffset(DateTime.MinValue), IsDismissed: true);
}

using CleanArchitecture.Domain.Common;

using ErrorOr;

namespace CleanArchitecture.Domain.Customers;

public class Customer : Entity
{
    public Guid TenantId { get; }

    public DateTime DateTime { get; }

    public DateOnly Date => DateOnly.FromDateTime(DateTime.Date);

    public string Name { get; } = null!;

    public bool IsDismissed { get; private set; }

    public Customer(
        Guid tenantId,
        Guid subscriptionId,
        string name,
        DateTime dateTime,
        Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        TenantId = tenantId;
        Name = name;
        DateTime = dateTime;
    }

    public ErrorOr<Success> Dismiss()
    {
        if (IsDismissed)
        {
            return Error.Conflict(description: "Reminder already dismissed");
        }

        IsDismissed = true;

        return Result.Success;
    }

    private Customer()
    {
    }
}

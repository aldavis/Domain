using System;
using MediatR;

namespace TFL.Domain
{
	public interface IDomainEvent : INotification
	{
        Guid EventId { get; }

        DateTime OccurredOn { get; }
	}
    public class DomainEvent : IDomainEvent
    {
	    public DomainEvent()
	    {
		    EventId = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
	    }
	    public Guid EventId { get; }
	    public DateTime OccurredOn { get; }
    }
}

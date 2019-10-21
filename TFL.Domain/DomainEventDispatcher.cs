using System.Threading.Tasks;
using MediatR;

namespace TFL.Domain
{
	public interface IDomainEventDispatcher
	{
		Task DispatchEventsAsync(Entity entity);
	}

    public class EntityEventDispatcher : IDomainEventDispatcher
    {
	    readonly IMediator _mediator;

	    public EntityEventDispatcher(IMediator mediator)
	    {
		    _mediator = mediator;
	    }

        public async Task DispatchEventsAsync(Entity entity)
        {
	        foreach (var domainEvent in entity.Events)
	        {
		        await _mediator.Publish(domainEvent);
				entity.ClearEvents();
	        }
        }
    }
}

using System;
using System.Collections.Generic;

namespace TFL.Domain
{

	public interface IAggregateRoot { }

    public abstract class Entity
    {
	    readonly List<IDomainEvent> _events = new List<IDomainEvent>();

	    public Guid Id { get; protected set; }

	    protected Entity()
	    {
			Id = Guid.NewGuid();
	    }

	    public int Version { get; private set; } = -1;

        public IReadOnlyCollection<IDomainEvent> Events => _events?.AsReadOnly();

        protected void Apply(IDomainEvent @event)
        {
			EnsureValidState();

			_events.Add(@event);
        }

        protected abstract void EnsureValidState();

        public void ClearEvents() => _events.Clear();
    }
}

using System;
using TFL.Domain;
using TFL.Domain.Exceptions;
using Xunit;
using Xunit.Sdk;

namespace Specs
{
	public class ValidStateEntity : Entity
	{

		protected override void EnsureValidState()
		{
		}

		public void AddEvent()
		{
			Apply(new TestDomainEvent());
		}
	}

    public class InvalidStateEntity : Entity
    {
	    public void AddEvent()
	    {
		    Apply(new TestDomainEvent());
	    }

        protected override void EnsureValidState()
	    {
		    throw new BusinessRuleViolation("Entity is in an invalid state.");
	    }
    }

	public class TestDomainEvent :IDomainEvent
	{
		public Guid EventId { get; }

		public DateTime OccurredOn { get; }
	}

	public class EntitySpecs
	{
		[Fact]
		public void entity_with_invalid_state_throws_business_rule_exception_when_events_are_applied()
		{
			var invalidEntity = new InvalidStateEntity();

			Assert.Throws<BusinessRuleViolation>(() => invalidEntity.AddEvent());
		}

		[Fact]
		public void entity_with_valid_state_does_not_throw_business_rule_exception_when_events_are_applied()
		{
			var validEntity = new ValidStateEntity();

			validEntity.AddEvent();

			Assert.True(validEntity.Events.Count == 1);
		}
    }
}

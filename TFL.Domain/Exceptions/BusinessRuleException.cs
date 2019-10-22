using System;

namespace TFL.Domain.Exceptions
{
	public class BusinessRuleViolation : Exception
	{
		public string Details { get; }

		public BusinessRuleViolation(string message) : base(message){}

		public BusinessRuleViolation(string message, string details) : base(message)
		{
			Details = details;
		}
	}
}

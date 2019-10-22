using System;

namespace TFL.Domain.Exceptions
{
	public class InvalidValue : Exception
	{
		public InvalidValue(Type type, string message)
			: base($"Value of {type.Name} {message}") { }
	}
}
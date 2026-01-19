using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Exceptions
{
	[Serializable]
	public class IconMappingNotFoundException : Exception
	{
		public IconMappingNotFoundException() { }
		public IconMappingNotFoundException(string message) : base(message) { }
		public IconMappingNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected IconMappingNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}

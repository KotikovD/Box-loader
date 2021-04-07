using System;

namespace BoxLoader
{
	public static class EnumUtil
	{
		public static T Parse<T>(string value)
		{
			return (T) Enum.Parse(typeof(T), value, true);
		}
	}
}
using System;
using UnityEngine;


namespace BoxLoader
{
	public static class CustomUtils
	{
		
		/// <summary>
		/// Multiply X and Z directions, and set source Y from multiplier vector
		/// </summary>
		public static Vector3 MultiplyTwoDirections(this Vector3 own, Vector3 multiplier)
		{
			return new Vector3(own.x * multiplier.x, multiplier.y, own.z * multiplier.z);
		}
		
		public static T ParseEnum<T>(string value)
		{
			return (T) Enum.Parse(typeof(T), value, true);
		}
		
		public static void SetSize(this RectTransform trans, Vector2 newSize) 
		{
			var oldSize = trans.rect.size;
			var deltaSize = newSize - oldSize;
			trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
			trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
		}
		
		public static void SetWidth(this RectTransform trans, float newSize)
		{
			SetSize(trans, new Vector2(newSize, trans.rect.size.y));
		}
		
		public static void SetHeight(this RectTransform trans, float newSize) 
		{
			SetSize(trans, new Vector2(trans.rect.size.x, newSize));
		}
	}
}
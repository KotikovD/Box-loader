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
	}
}
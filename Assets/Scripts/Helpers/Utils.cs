using UnityEngine;

namespace BoxLoader
{
	//TODO what should i do with this class? 
	public static class Utils
	{
		/// <summary>
		/// Set Y by offset value, calculate X and Z offsets from target
		/// </summary>
		public static  Vector3 CalculateOffsetPosition(Vector3 targetPos, Vector3 offset)
		{
			var resultPos = offset;
			resultPos.x = targetPos.x + offset.x;
			resultPos.z = targetPos.z + offset.z;

			return resultPos;
		}
	}
}
using RSG;
using UnityEngine;


namespace BoxLoader
{
	public interface ICharacterView
	{
		void InitializeView(GameEntity entity, GameContext gameContext);
		IPromise Move(Vector3 destinationPoint);
		IPromise Pickup(float animationEventTime);
		IPromise DropBox(float animationEventTime);
		IPromise LookAt(Vector3 target);
		void DestroyCharacterComponent();
		Transform CarryPoint { get; }
	}
}
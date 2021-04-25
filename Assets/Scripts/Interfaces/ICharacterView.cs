using UnityEngine;
using UnityEngine.AI;


namespace BoxLoader
{
	public interface ICharacterView
	{
		void InitializeView(GameEntity entity);
		void Move(Vector3 destinationPoint);
		void Use(Vector3 destinationPoint);
		void DestroyCharacterComponent();
	}
}
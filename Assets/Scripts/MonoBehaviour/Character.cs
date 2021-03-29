using Entitas.Unity;
using UnityEngine;
using UnityEngine.AI;


namespace BoxLoader
{
	[RequireComponent(typeof(EntityLink))]
	public sealed class Character : MonoBehaviourExt, ICharacter
	{
		[SerializeField] private NavMeshAgent _navMeshAgent;
		[SerializeField] private Animator _animator;
		
		public void InitializeView(GameEntity entity)
		{
			 entity.AddCharacter(this);
		}

		public void Move(Vector3 destinationPoint)
		{
			_navMeshAgent.SetDestination(destinationPoint);
		}

		public void Use(Vector3 destinationPoint)
		{
			throw new System.NotImplementedException();
		}

		public void DestroyCharacterComponent()
		{
			Destroy(this);
			gameObject.Unlink();
		}

	}
}
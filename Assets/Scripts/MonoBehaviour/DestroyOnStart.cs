namespace BoxLoader
{
	public class DestroyOnStart : MonoBehaviourExt
	{
		private void Start()
		{
			Destroy(gameObject);
		}
	}
}
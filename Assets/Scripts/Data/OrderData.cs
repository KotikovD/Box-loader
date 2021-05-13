namespace BoxLoader
{
	public class BoxesOrder
	{
		public BoxType BoxType { get; }
		public bool IsComplete { get; set; }

		public BoxesOrder(BoxType boxType, bool isComplete)
		{
			BoxType = boxType;
			IsComplete = isComplete;
		}
	}
}
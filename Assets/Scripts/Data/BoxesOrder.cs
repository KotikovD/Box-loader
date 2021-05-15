namespace BoxLoader
{
	public class BoxesOrder
	{
		public BoxType BoxType { get; }
		public bool IsComplete { get; set; }
		public string BoxLocalization { get; }

		public BoxesOrder(BoxType boxType, string boxLocalization, bool isComplete)
		{
			BoxType = boxType;
			BoxLocalization = boxLocalization;
			IsComplete = isComplete;
		}
	}
}
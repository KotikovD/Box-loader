using System.Collections.Generic;
using UnityEngine;

namespace BoxLoader
{
	public interface IOrderUiView
	{
		void Initialize(OrderStrokeUiView strokePrefab,
			Color defaultStrokeColor,
			Color completeStrokeColor,
			float alarmTime,
			Color defaultTimerColor,
			Color alarmTimerColor,
			string noOrderLocalization);
		void UpdateAnchors(Vector2 newPosition);
		void RemoveCurrentOrder(bool isNeedCreateMock);
		void CreateOrderUi(List<BoxesOrder> boxes, float orderTimer);
		void SetNextComplete();
	}
}
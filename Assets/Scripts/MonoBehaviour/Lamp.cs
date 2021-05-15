using System;
using UnityEngine;


namespace BoxLoader
{
	public class Lamp : MonoBehaviourExt
	{
		[SerializeField] private Light _light;
		
		private readonly LampBehaviour _noOrderLampBehaviour = new LampOffBehaviour();
		private readonly LampBehaviour _timeOffOrderLampBehaviour = new LampRedAlarmBehaviour();
		private readonly LampBehaviour _processingOrderLampBehaviour = new LampYellowShineBehaviour();
		private LampBehaviour _activeBehaviour = new LampOffBehaviour();
		
		public void NoOrderLampBehaviour()
		{
			if(_activeBehaviour.Equals(_noOrderLampBehaviour))
				return;
			
			_activeBehaviour.Deactivate(_light);
			_activeBehaviour = _noOrderLampBehaviour;
			_activeBehaviour.Activate(_light);
		}

		public void TimeOffOrderLampBehaviour()
		{
			if(_activeBehaviour.Equals(_timeOffOrderLampBehaviour))
				return;
			
			_activeBehaviour.Deactivate(_light);
			_activeBehaviour = _timeOffOrderLampBehaviour;
			_activeBehaviour.Activate(_light);
		}

		public void ProcessingOrderLampBehaviour()
		{
			if(_activeBehaviour.Equals(_processingOrderLampBehaviour))
				return;
			
			_activeBehaviour.Deactivate(_light);
			_activeBehaviour = _processingOrderLampBehaviour;
			_activeBehaviour.Activate(_light);
		}
		
	}
}
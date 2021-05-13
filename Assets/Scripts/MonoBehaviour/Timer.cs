using System.Collections;
using NaughtyAttributes;
using UnityEngine;

//TODO remove this shit
namespace BoxLoader
{
	public class Timer : MonoBehaviourExt
	{
		[ReadOnly] private int _timerValue = 0;
		private IEnumerator _coroutine;
		
		public int TimerValueValue => _timerValue;
		
		void Start()
		{
			_coroutine = GameTimer();
		}
		
		private IEnumerator GameTimer()
		{
			while (Application.isFocused)
			{
				yield return new WaitForSeconds(1);
				_timerValue++;
			}
		}
	}
}
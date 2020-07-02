using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedActivation : MonoBehaviour
{
	public UnityEvent OnActivationEvent;

	[SerializeField]
	private float _secondsBeforeActivation;

	public void ActivateCountDown()
	{
		Invoke("ActivateEvent", _secondsBeforeActivation);
	}

	public void ActivateEvent()
	{
		OnActivationEvent.Invoke();
	}

		
}

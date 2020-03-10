using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCallOnTrigger : MonoBehaviour
{
	public UnityEvent OnTriggerEnterEvent;
	public UnityEvent OnTriggerExitEvent;

	[SerializeField, Tooltip("Whether or not the trigger events will only call if they interact with a specific object.")]
	private bool useSpecificObject;
	[SerializeField, Tooltip("Which object needs to hit this trigger/object to activate.")]
	private Transform specificObject;

	private void OnTriggerEnter(Collider other)
	{
		if (OnTriggerEnterEvent != null && IsSpecificObject(other))
			OnTriggerEnterEvent.Invoke();
	}

	private void OnTriggerExit(Collider other)
	{
		if (OnTriggerExitEvent != null)
			OnTriggerExitEvent.Invoke();
	}

	private bool IsSpecificObject(Collider other)
	{
		if (!useSpecificObject) return true;
		else return other.transform.Equals(specificObject);
	}
}

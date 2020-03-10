using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectFloatManager : MonoBehaviour
{
	[SerializeField]
	private List<ObjectFloat> _affectedObjects;

	private bool isFloating;

	public UnityEvent OnObjectsFloatEvent;
	public UnityEvent OnObjectsStopFloatEvent;

	public void StartObjectsFloat()
	{
		_affectedObjects.ForEach(x => x.TriggerFloat());
		isFloating = true;

		if (OnObjectsFloatEvent != null)
			OnObjectsFloatEvent.Invoke();
	}

	public void EndObjectsFloat()
	{
		_affectedObjects.ForEach(x => x.StopFloat());
		isFloating = false;

		if (OnObjectsStopFloatEvent != null)
			OnObjectsStopFloatEvent.Invoke();
	}

	public void ToggleFloat()
	{
		isFloating = !isFloating;

		if (isFloating) StartObjectsFloat();
		else			EndObjectsFloat();
	}


}

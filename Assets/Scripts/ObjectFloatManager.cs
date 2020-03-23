using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectFloatManager : MonoBehaviour
{
	[SerializeField]
	private List<ObjectFloat> _affectedObjects;

	private bool _isFloating;

	public UnityEvent OnObjectsFloatEvent;
	public UnityEvent OnObjectsStopFloatEvent;

	public void StartObjectsFloat()
	{
		if (_isFloating) return;

		_affectedObjects.ForEach(x => x.TriggerFloat());
		_isFloating = true;

		if (OnObjectsFloatEvent != null)
			OnObjectsFloatEvent.Invoke();
	}

	public void EndObjectsFloat()
	{
		if (!_isFloating) return;

		_affectedObjects.ForEach(x => x.StopFloat());
		_isFloating = false;

		if (OnObjectsStopFloatEvent != null)
			OnObjectsStopFloatEvent.Invoke();
	}

	public void ToggleFloat()
	{
		_isFloating = !_isFloating;

		if (_isFloating) StartObjectsFloat();
		else			EndObjectsFloat();
	}

	public bool IsCurrentlyFloating()
	{
		return _isFloating;
	}
}

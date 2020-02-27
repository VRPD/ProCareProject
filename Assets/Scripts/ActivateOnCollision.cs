using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateOnCollision : MonoBehaviour
{
	[SerializeField]
	private string tagToActivate;

	[SerializeField]
	private UnityEvent activatedEvent;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == tagToActivate)
		{
			activatedEvent.Invoke();
		}
	}
}

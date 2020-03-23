using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

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
			GetComponent<Throwable>().enabled = false;
			transform.position = new Vector3(0,2,0);
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}

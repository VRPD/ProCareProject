using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectFloat : MonoBehaviour
{
	[SerializeField]
	private bool debugActivate = false;
	[SerializeField, Range(0, 10)]
	private float _upwardsForce = 3;
	[SerializeField, Range(0, 5)]
	private float _torqueStrength = 0.5f;
	[SerializeField, Range(0, 25)]
	private float _dragAddition = 2;

	private Rigidbody _rigidBody;
	private bool aaah = false;

    // Start is called before the first frame update
    void Awake()
    {
		_rigidBody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        if (debugActivate && !aaah)
		{
			aaah = true;
			TriggerFloat();
		}
    }


	public void TriggerFloat()
	{
		_rigidBody.WakeUp();
		_rigidBody.useGravity = false;
		_rigidBody.AddForce(Vector3.up * _upwardsForce, ForceMode.Impulse);
		_rigidBody.AddRelativeTorque(Vector3.one * UnityEngine.Random.Range(-_torqueStrength, _torqueStrength), ForceMode.Impulse);
		_rigidBody.drag += _dragAddition;
		_rigidBody.angularDrag += _dragAddition;
	}

	public void StopFloat()
	{

		_rigidBody.WakeUp();
		_rigidBody.useGravity = true;
		_rigidBody.drag -= _dragAddition;
		_rigidBody.angularDrag -= _dragAddition;

	}

}

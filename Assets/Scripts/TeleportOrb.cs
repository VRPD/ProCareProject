using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TeleportOrb : MonoBehaviour
{
	[SerializeField]
	private Throwable _throwable;
	[SerializeField]
	private Interactable _interactable;
	[SerializeField]
	private Rigidbody _rigidbody;

	[SerializeField]
	private GameObject _fadeObject;
	[SerializeField, Range(0.05f, 1f)]
	private float _speedForActivation = 0.3f;

	[SerializeField]
	private string _sceneNameToJumpTo;

	[SerializeField]
	private TMPro.TextMeshProUGUI _previewText;

	private bool _activatePortal;
	private bool _returningToPosition;

	private Vector3 lastPosition;
	private Vector3 startPosition;

	private void Awake()
	{
		startPosition = transform.position;
		_throwable.onDetachFromHand.AddListener(OnDetach);
		_throwable.onPickUp.AddListener(OnPickup);
		_rigidbody.constraints = RigidbodyConstraints.FreezePosition;

		_previewText.text = "Teleport to \n " + _sceneNameToJumpTo;
	}

	private void OnDetach()
	{
		lastPosition = transform.position;
		_rigidbody.constraints = RigidbodyConstraints.None;
		Invoke("CheckIfPortal", 0.1f);
	}

	private void OnPickup()
	{
		startPosition = transform.position;
	}

	public void CheckIfPortal()
	{
		Debug.Log(Vector3.Distance(transform.position, lastPosition));
		if (Vector3.Distance(transform.position, lastPosition) > _speedForActivation)
		{
			_rigidbody.useGravity = true;
			_activatePortal = true;
		}
		else
		{
			transform.position = startPosition;
			_throwable.enabled = true;
			_interactable.enabled = true;
			_rigidbody.constraints = RigidbodyConstraints.FreezePosition;
			_rigidbody.angularVelocity = Vector3.zero;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (_activatePortal)
		{
			gameObject.SetActive(false);
			_fadeObject.SetActive(true);
			Invoke("LoadNewLevel", 2f);
		}
	}

	public void LoadNewLevel()
	{
		Destroy(GameObject.Find("Player (ProCare Edits)"));
		SceneManager.LoadScene(_sceneNameToJumpTo, LoadSceneMode.Single);
	}

}

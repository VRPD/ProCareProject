using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using static Valve.VR.SteamVR_Action_Boolean;

[RequireComponent(typeof(Player))]
public class RaycastClick : MonoBehaviour
{
	private Player _player;
	private Transform _origin;

	[SerializeField, Range(1f, 25f)]
	private float _maxRayDistance = 10;
	[SerializeField]
	private bool showDebug;
	
	private void Awake()
    {
		// Add listener to hands
		_player = GetComponent<Player>();

		_player.leftHand.grabGripAction.AddOnChangeListener(OnHandTrigger, SteamVR_Input_Sources.LeftHand);
		_player.rightHand.grabGripAction.AddOnChangeListener(OnHandTrigger, SteamVR_Input_Sources.RightHand);
	}

	private void OnHandTrigger(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
	{

		// Get the appropiate origin depending on the input source
		if (fromSource == SteamVR_Input_Sources.LeftHand)
			_origin = _player.leftHand.transform;
		else
			_origin = _player.rightHand.transform;

		// Use a simple raycast to find an object
		RaycastHit rayHit;
		if (Physics.Raycast(new Ray(_origin.transform.position, _origin.transform.forward), out rayHit, _maxRayDistance))
		{
			Debug.Log(rayHit.collider.gameObject.name);
			Button button = rayHit.collider.gameObject.transform.parent.GetComponent<Button>();
			//Check if the target hit has a (UI) button, if so we invoke the OnClick event, essentially pushing the button
			if (button)
				button.onClick.Invoke();
		}
	}

    private void Update()
    {
		if (showDebug)
		{
			Debug.DrawRay(_player.leftHand.transform.position, _player.leftHand.transform.forward, Color.blue);
			Debug.DrawRay(_player.leftHand.transform.position + _player.leftHand.transform.forward, _player.leftHand.transform.forward * 3f, Color.red);

			Debug.DrawRay(_player.rightHand.transform.position, _player.rightHand.transform.forward, Color.blue);
			Debug.DrawRay(_player.rightHand.transform.position + _player.rightHand.transform.forward, _player.rightHand.transform.forward * 3f, Color.red);
		}
    }
}

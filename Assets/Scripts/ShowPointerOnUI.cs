using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class ShowPointerOnUI : MonoBehaviour
{
	[SerializeField]
	private Player _player;
	[SerializeField, Range(1f, 25f)]
	private float _maxRayDistance = 10;

	private SteamVR_LaserPointer[] _pointers;
    
    private void Awake()
    {
        if (!_player)
			GameObject.Find("Player").GetComponent<Player>();

		_pointers = new SteamVR_LaserPointer[2];
		_pointers[0] = _player.leftHand.GetComponent<SteamVR_LaserPointer>();
		_pointers[1] = _player.rightHand.GetComponent<SteamVR_LaserPointer>();
	}

	// Update is called once per frame
	private void Update()
	{
		// Maaaybe add in a refresh rate to reduce the amount of calls? Since it's a simple toggle I believe the latency wouldn't be as noticable.

		RaycastHit rayHit;
		// Left Hand
		if (Physics.Raycast(new Ray(_player.leftHand.transform.position, _player.leftHand.transform.forward), out rayHit, _maxRayDistance))
		{
			// If we hit an UI element (would like to avoid comparing tags due to the memory leakage and room for error)
			if (rayHit.collider.tag == "ShowLaserCursor")
				_pointers[0].enabled = true;
			else
				_pointers[0].enabled = false;
		}

		// Right Hand
		rayHit = new RaycastHit();
		if (Physics.Raycast(new Ray(_player.rightHand.transform.position, _player.rightHand.transform.forward), out rayHit, _maxRayDistance))
		{
			// If we hit an UI element (would like to avoid comparing tags due to the memory leakage and room for error)
			if (rayHit.collider.tag == "ShowLaserCursor")
				_pointers[1].enabled = true;
			else
				_pointers[1].enabled = false;
		}
	}
}

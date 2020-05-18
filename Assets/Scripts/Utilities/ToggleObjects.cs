using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToggleObjects : MonoBehaviour
{

	[SerializeField]
	private GameObject[] _gameObjects;
	public SteamVR_Action_Boolean toggleAction;
	public SteamVR_Input_Sources handType;

	void Start()
	{
		toggleAction.AddOnStateDownListener(TriggerDown, handType);
	}

	public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
	{
		for (int i = 0; i < _gameObjects.Length; i++)
		{
			_gameObjects[i].SetActive(!_gameObjects[i].activeSelf);
		}
	}
}

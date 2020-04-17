using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(UIElementExpanded))]
public class SoundsOnHandInteraction : MonoBehaviour
{
	[SerializeField]
	private UISoundPlayer _player;
	
    void Awake()
    {
		UIElementExpanded uiStuff = GetComponent<UIElementExpanded>();

		uiStuff.onHandHover.AddListener(OnHandHover);
		uiStuff.onHandClick.AddListener(OnHandClick);
	}

	private void OnHandClick(Hand arg0)
	{
		_player.PlayClickSound();
	}

	private void OnHandHover(Hand arg0)
	{
		_player.PlayHoverSound();
	}
}

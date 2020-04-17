using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundPlayer : MonoBehaviour
{
	[SerializeField]
	private AudioSource _source;

	[SerializeField]
	private AudioClip _soundOnHover;

	[SerializeField]
	private AudioClip _soundOnClick;
	
	public void PlayHoverSound()
	{
		_source.clip = _soundOnHover;
		_source.Play();
	}

	public void PlayClickSound()
	{
		_source.clip = _soundOnClick;
		_source.Play();
	}
}

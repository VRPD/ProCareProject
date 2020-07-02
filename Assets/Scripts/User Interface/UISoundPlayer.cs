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

	[SerializeField, Range(0, 0.5f)]
	private float _pitchVariance = 0.1f;
	
	public void PlayHoverSound()
	{
		_source.clip = _soundOnHover;
		_source.pitch = 1 + Random.Range(-_pitchVariance, _pitchVariance);
		_source.Play();
	}

	public void PlayClickSound()
	{
		_source.clip = _soundOnClick;
		_source.pitch = 1 + Random.Range(-_pitchVariance, _pitchVariance);
		_source.Play();
	}
}

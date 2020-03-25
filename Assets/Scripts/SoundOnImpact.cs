using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SoundOnImpact : MonoBehaviour
{
	[SerializeField]
	private AudioSource _audioSource;
	[SerializeField, Range(0f, 2f)]
	private float _pitchVariance = 0.2f;
	[SerializeField]
	private bool useCollisionStay = true;


	private float _pitchStart;

	private void Awake()
	{
		_pitchStart = _audioSource.pitch;
	}

	private void OnCollisionEnter(Collision collision)
	{
		float audioVolume = collision.relativeVelocity.magnitude / 10f;
		_audioSource.volume = audioVolume;
		_audioSource.pitch = _pitchStart + Random.Range(-_pitchVariance, _pitchVariance);
		_audioSource.Play();
	}

	private void OnCollisionStay(Collision collision)
	{
		if (useCollisionStay && ((collision.relativeVelocity.magnitude / 10f) >= _audioSource.volume || !_audioSource.isPlaying))
		{
			float audioVolume = collision.relativeVelocity.magnitude / 10f;
			_audioSource.volume = audioVolume;
			_audioSource.pitch = _pitchStart + Random.Range(-_pitchVariance, _pitchVariance);
			_audioSource.Play();
		}
	}
}

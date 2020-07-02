using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredAudio : MonoBehaviour
{
	[SerializeField]
	private AudioSource _baseSound;
	[SerializeField]
	private AudioSource _layeredSound;

	[SerializeField]
	private bool easeVolume;
	[SerializeField, Range(0.001f, 0.1f)]
	private float volumeChangePerFrame = 0.05f;

	private void Awake()
	{
		if (easeVolume)
		{
			_layeredSound.volume = 0;
			_layeredSound.Play();
		}
	}

	public void StartLayeredSound(bool stopBaseSound)
	{
		if (easeVolume)
		{
			StopAllCoroutines();
			StartCoroutine(EaseAudio(_layeredSound, 0.4f));
			StartCoroutine(EaseAudio(_baseSound, 0));
		} else
		{
			if (_baseSound.isPlaying)
			{
				_layeredSound.Play();
				_layeredSound.time = _baseSound.time;
				if (stopBaseSound)
					_baseSound.Stop();
			}
		}
	}

	public void StopLayeredSound()
	{
		if (easeVolume)
		{
			StopAllCoroutines();
			StartCoroutine(EaseAudio(_layeredSound, 0));
			StartCoroutine(EaseAudio(_baseSound, 0.4f));
		}
		else
		{
			if (!_baseSound.isPlaying)
			{
				_baseSound.time = _layeredSound.time;
				_baseSound.Play();
			}
			_layeredSound.Stop();
		}
		
	}

	private IEnumerator EaseAudio(AudioSource source, float volumeDestination)
	{
		float increment;
		if (volumeDestination == 0.4f) increment = volumeChangePerFrame;
		else increment = -volumeChangePerFrame;

		while (source.volume != volumeDestination)
		{
			source.volume += increment;
			yield return new WaitForFixedUpdate();
		}

		source.volume = 0.4f;
	}
}

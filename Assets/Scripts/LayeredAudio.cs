using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredAudio : MonoBehaviour
{
	[SerializeField]
	private AudioSource _baseSound;
	[SerializeField]
	private AudioSource _layeredSound;

	public void StartLayeredSound(bool stopBaseSound)
	{
		if (_baseSound.isPlaying)
		{
			_layeredSound.Play();
			_layeredSound.time = _baseSound.time;

			if (stopBaseSound) _baseSound.Stop();
		}
	}

	public void StopLayeredSound()
	{
		_layeredSound.Stop();
	}
}

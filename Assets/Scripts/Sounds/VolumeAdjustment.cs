using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VolumeAdjustment : MonoBehaviour
{
	[SerializeField, Header("References")]
	private AudioSource[] _volumeSources;
	[SerializeField]
	private TMPro.TextMeshProUGUI _percentage;

	[SerializeField, Header("Variables")]
	private float _volume = 1;

	[SerializeField, Header("Events")]
	private UnityEvent<float> OnVolumeChange;

	public void IncreaseVolume(float increase)
	{
		_volume += increase;

		if (_volume > 1) _volume = 1;
		if (_percentage) UpdateText();

		OnVolumeChange.Invoke(_volume);
	}

	public void DecreaseVolume(float decrease)
	{
		_volume -= decrease;

		if (_volume < 0) _volume = 0;
		if (_percentage) UpdateText();

		OnVolumeChange.Invoke(_volume);
	}

	public void UpdateText()
	{
		_percentage.text = (_volume * 100) + "%";
	}

}

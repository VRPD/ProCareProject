using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventFloat : UnityEvent<float>
{
}

public class VolumeAdjustment : MonoBehaviour
{
	[SerializeField, Header("References")]
	private AudioSource[] _volumeSources;
	[SerializeField]
	private TMPro.TextMeshProUGUI _percentage;

	[SerializeField, Header("Variables")]
	private float _volume = 1;
	[SerializeField, Range(0, 1)]
	private float _minimumValue = 0;
	[SerializeField, Range(0, 1)]
	private float _maximumValue = 1;

	[Header("Events")]
	public UnityEventFloat OnVolumeChange = new UnityEventFloat();

	public void IncreaseVolume(float increase)
	{
		_volume += increase;

		if (_volume > _maximumValue) _volume = _maximumValue;
		if (_percentage) UpdateText();

		OnVolumeChange.Invoke(_volume);
	}

	public void DecreaseVolume(float decrease)
	{
		_volume -= decrease;

		if (_volume < _minimumValue) _volume = _minimumValue;
		if (_percentage) UpdateText();

		OnVolumeChange.Invoke(_volume);
	}

	public void UpdateText()
	{
		_percentage.text = Mathf.RoundToInt(_volume * 100) + "%";
	}

}

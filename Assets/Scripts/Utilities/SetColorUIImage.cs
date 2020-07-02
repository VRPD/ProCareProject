using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorUIImage : MonoBehaviour
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TMPro.TextMeshProUGUI _text;

	public void SetColor(Color color)
	{
		if (_image)
			_image.color = color;
		else
			_text.color = color;
	}

	// Preset stuff

	public void SetColorWhite()
	{
		if (_image)
			_image.color = Color.white;
		else
			_text.color = Color.white;
	}

	public void SetColorBlue()
	{
		if (_image)
			_image.color = Color.blue;
		else
			_text.color = Color.blue;
	}

	public void SetColorRed()
	{
		if (_image)
			_image.color = Color.red;
		else
			_text.color = Color.red;
	}

	public void SetColorGreen()
	{
		if (_image)
			_image.color = Color.green;
		else
			_text.color = Color.green;
	}

	public void SetColorGrey()
	{
		if (_image)
			_image.color = Color.grey;
		else
			_text.color = Color.grey;
	}
}

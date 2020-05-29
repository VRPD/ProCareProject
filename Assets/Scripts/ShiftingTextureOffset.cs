using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShiftingTextureOffset : MonoBehaviour
{
	[SerializeField]
	private Material _material;
	[SerializeField, Range(0.1f, 5)]
	private float _speed = 1;

	private string _vectorID = "Vector2_8718CC1E";


	private void Awake()
	{
		_material.SetVector(_vectorID, new Vector4(0, 0, 0, 0));
	}

	// Update is called once per frame
	void Update()
    {
		if (Application.isPlaying)
			_material.SetVector(_vectorID, new Vector4(0, Time.time * _speed, 0, 0));
    }
}

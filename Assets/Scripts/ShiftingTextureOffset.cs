using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingTextureOffset : MonoBehaviour
{
	[SerializeField]
	private Material _material;
	[SerializeField, Range(0.1f, 5)]
	private float _speed = 1;

	private string _vectorID = "Vector2_8718CC1E";

	// Update is called once per frame
	void Update()
    {
		_material.SetVector(_vectorID, new Vector4(0, Time.time * _speed, 0, 0));
    }
}

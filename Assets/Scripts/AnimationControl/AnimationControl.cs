using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControl : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	// Start is called before the first frame update
	void Start()
	{

	}

	/*private void GravityChanged(float arg0)
	{
		for (int i = 0; i < _blendTree.children.Length; i++)
		{
			_blendTree.children[i].timeScale = arg0;
		}
	}*/

	public void SpeedChanged(float arg0)
	{
		_animator.SetFloat("Running Speed", arg0);
	}

	// Update is called once per frame
	void Update()
	{

	}
}

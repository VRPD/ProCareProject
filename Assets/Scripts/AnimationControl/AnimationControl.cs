using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControl : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private Slider _speedSlider;
	[SerializeField]
	private Slider _gravitySlider;
	[SerializeField]
	private BlendTree _blendTree;

	// Start is called before the first frame update
	void Start()
    {
		//_animator.Play("stateName");
		_speedSlider.onValueChanged.AddListener(SpeedChanged);
		//_gravitySlider.onValueChanged.AddListener(GravityChanged);
		//_blendTree = _animator.runtimeAnimatorController.
    }

	private void GravityChanged(float arg0)
	{
		for (int i = 0; i < _blendTree.children.Length; i++)
		{
			_blendTree.children[i].timeScale = arg0;
		}
	}

	private void SpeedChanged(float arg0)
	{
		_animator.SetFloat("Running Speed", arg0);
	}

	// Update is called once per frame
	void Update()
    {
		
    }
}

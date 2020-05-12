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

	[Header("No")]
	[SerializeField]
	private VolumeAdjustment _speedAdjustment;
	[SerializeField]
	private VolumeAdjustment _gravityAdjustment;

	// Start is called before the first frame update
	void Awake()
    {
		//_animator.Play("stateName");
		
		//if (_speedSlider)
		//	_speedSlider.onValueChanged.AddListener(SpeedChanged);
		//else
		_speedAdjustment.OnVolumeChange.AddListener(SpeedChanged);

		//_gravitySlider.onValueChanged.AddListener(GravityChanged);
		//_blendTree = _animator.runtimeAnimatorController.
	}

	private void GravityChanged(float value)
	{
		for (int i = 0; i < _blendTree.children.Length; i++)
		{
			_blendTree.children[i].timeScale = value;
		}
	}

	private void SpeedChanged(float value)
	{
		_animator.SetFloat("Running Speed", value);
	}

	// Update is called once per frame
	void Update()
    {
		
    }
}

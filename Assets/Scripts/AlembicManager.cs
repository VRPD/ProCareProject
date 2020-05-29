using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class AlembicAnimation
{
	public GameObject _object;
	public string _name;
}

// AlembicPlayer is below this class!

public class AlembicManager : MonoBehaviour
{
	[SerializeField]
	private AlembicAnimation[] _animations;

	private AlembicPlayer _player;
	private int _currentAnimation = 0;

	// Start is called before the first frame update
	private void Start()
	{
		_player = new AlembicPlayer();
		_player.OnAnimationFinished.AddListener(OnAnimationComplete);

		_player.AssignNewStreamPlayer(new SerializedObject(_animations[0]._object.GetComponent("AlembicStreamPlayer")), true);
	}

	private void OnAnimationComplete()
	{
		_animations[_currentAnimation]._object.SetActive(false);

		_currentAnimation++;

		if (_currentAnimation == _animations.Length)
			return;

		_player.AssignNewStreamPlayer(new SerializedObject(_animations[_currentAnimation]._object.GetComponent("AlembicStreamPlayer")), true);
		_animations[_currentAnimation]._object.SetActive(true);
	}
	

	private void Update()
	{
		_player.Update();
	}

	public void PlayAnimation(string name)
	{
		int newAnimationID = FindAnimationByName(name);
		if (newAnimationID != -1)
		{
			_currentAnimation = newAnimationID;
			_player.AssignNewStreamPlayer(new SerializedObject(_animations[_currentAnimation]._object.GetComponent("AlembicStreamPlayer")), true);
		}
	}

	private int FindAnimationByName(string name)
	{
		for (int i = 0; i < _animations.Length; i++)
		{
			if (_animations[i]._name == name)
				return i;
		}

		Debug.LogError("Couldn't find the animation!");
		return -1;
	}
}

public class AlembicPlayer
{
	private SerializedObject _alembicStream;
	private SerializedProperty _currentTime;

	private bool _isPlaying = false;
	private float _startTime;
	private float _endTime;

	public UnityEvent OnAnimationFinished;

	public AlembicPlayer()
	{
		OnAnimationFinished = new UnityEvent();
	}

	public void AssignNewStreamPlayer(SerializedObject player, bool autoPlay)
	{
		_alembicStream = player;
		_currentTime = player.FindProperty("currentTime");
		// Don't need to keep proper track of these values as they shouldn't change while running.
		_startTime = player.FindProperty("startTime").floatValue;
		_endTime = player.FindProperty("endTime").floatValue;

		if (autoPlay)
			Play();
	}

	public void Play()
	{
		if (_alembicStream == null || _isPlaying)
			return;

		_isPlaying = true;
		_currentTime.floatValue = 0;
		_alembicStream.ApplyModifiedProperties();
	}
	
	public void Update()
	{
		if (_isPlaying)
		{
			_currentTime.floatValue += Time.deltaTime;

			if (_currentTime.floatValue >= _endTime)
			{
				_isPlaying = false;
				OnAnimationFinished.Invoke();
			}
			
			_alembicStream.ApplyModifiedProperties();
		}
	}
}

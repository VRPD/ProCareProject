using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterGMachine : MonoBehaviour
{
	[Header("References")]

	[SerializeField]
	private ObjectFloatManager _floatManager;


	[Header("Variables")]
	[SerializeField]
	private int _weightPercentage = 100;
	
    void Awake()
    {
        if (!_floatManager)
			_floatManager = GetComponent<ObjectFloatManager>();
    }

	public void IncreaseWeight(int increment)
	{
		_weightPercentage += increment;
		if (_weightPercentage > 100)
			_weightPercentage = 100;

		CheckForEvents();
	}

	public void DecreaseWeight(int increment)
	{
		_weightPercentage -= increment;
		if (_weightPercentage < 20)
			_weightPercentage = 20;

		CheckForEvents();
	}

	private void CheckForEvents()
	{
		if (_weightPercentage == 20)
		{
			_floatManager.StartObjectsFloat();
		} else if (_floatManager.IsCurrentlyFloating() && _weightPercentage >= 30)
		{
			_floatManager.EndObjectsFloat();
		}
	}

	public int GetWeightPercentage()
	{
		return _weightPercentage;
	}
}

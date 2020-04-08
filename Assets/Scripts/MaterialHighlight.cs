using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHighlight : MonoBehaviour
{
	[Header("Material")]
	[SerializeField]
	private Material _material;
	[SerializeField]
	private string _highlightStrengthPropertyID = "Vector1_B1CE3997";
	[SerializeField]
	private string _highlightMapPropertyID = "Texture2D_AA866AD1";
	[SerializeField]
	private Texture2D[] _highlightTextures;

	[Header("General")]
	[SerializeField]
	private AnimationCurve _transitionCurve;

	private float currentHighlightDuration;
	
    private void Awake()
    {
        if (!_material)
		{
			_material = GetComponent<MeshRenderer>().material;
			if (!_material) Debug.LogError("Couldn't find the material! MaterialHighlight will NOT function properly.");
		}


		_material.SetFloat(_highlightStrengthPropertyID, 0);
	}

	public void SetHighlightTexture(int id)
	{
		_material.SetTexture(_highlightMapPropertyID, _highlightTextures[id]);
	}

	public void SetHighlightTexture(Texture2D texture)
	{
		_material.SetTexture(_highlightMapPropertyID, texture);
	}

	public void StartHighlight(float duration)
	{
		if (duration == -1) duration = float.MaxValue;
		currentHighlightDuration = duration;

		StartCoroutine(HandleHighlight());
	}

	private IEnumerator HandleHighlight()
	{
		// Setup
		float transition = 0;

		// Initial curve
		while (transition < 1)
		{
			_material.SetFloat(_highlightStrengthPropertyID, _transitionCurve.Evaluate(transition));
			transition += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		// Pause for X seconds
		yield return new WaitForSeconds(currentHighlightDuration);

		// Return curve
		while (transition > 0)
		{
			_material.SetFloat(_highlightStrengthPropertyID, _transitionCurve.Evaluate(transition));
			transition -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
}

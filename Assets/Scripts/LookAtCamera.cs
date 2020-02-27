using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProCare.Sim.Utilities
{
	public class LookAtCamera : MonoBehaviour
	{
		[SerializeField]
		private Camera target;

		private void Update()
		{
			transform.LookAt(target.transform);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaysInput : MonoBehaviour
{
	[SerializeField]
	private AlterGMachine _alterG;
	[SerializeField]
	private TMPro.TextMeshProUGUI _info;
	
    void Update()
    {
		_info.text = _alterG.GetWeightPercentage().ToString();
    }
}

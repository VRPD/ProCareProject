using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkenOnAwake : MonoBehaviour
{
	[SerializeField]
	private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
		{
			_image.color = new Color(0, 0, 0, _image.color.a + 0.01f);
		}
    }
}

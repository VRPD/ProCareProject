using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    public SpriteRenderer rend;
    Color spriteCol;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        spriteCol = rend.material.color;
        spriteCol.a = 0f;

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            spriteCol = rend.material.color;
            spriteCol.a = f;
            rend.material.color = spriteCol;
            yield return new WaitForSeconds(0.05f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public int yTarget, speed;

    public void MoveCaller()
    {
        StartCoroutine(moveObject());
    }

    IEnumerator moveObject()
    {
        while (gameObject.transform.position.y < yTarget)
        {
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);

            yield return null;
        }

    }
}

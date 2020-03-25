using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenu : MonoBehaviour, IContainAction
{
    public GameObject[] menuObjects;
    private bool isOpen = false;
    void Start()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(false);
        }
    }

  public void CustomAction()
    {
        if (!isOpen)
        {
            foreach (GameObject obj in menuObjects)
            {
                obj.SetActive(true);
            }
            isOpen = true;
        }
        else
        {
            foreach (GameObject obj in menuObjects)
            {
                obj.SetActive(false);
            }
            isOpen = false;
        }
    }
}

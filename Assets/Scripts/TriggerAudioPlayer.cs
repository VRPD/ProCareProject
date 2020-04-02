using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayNarration audioManager;

    public int clipNo;

    private void Start()
    {
        audioManager = GetComponentInParent<PlayNarration>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioManager.PlayNextClip(clipNo);
        }
    }
}

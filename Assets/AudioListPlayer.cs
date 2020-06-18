using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSrc;
    void Start()
    {
        audioSrc.GetComponent<AudioSource>();
        StartCoroutine(playClips());
    }

    IEnumerator playClips()
    {
        for (int i = 0; i < clips.Length; i++)
        {
            audioSrc.clip = clips[i];
            audioSrc.Play();
            yield return new WaitForSeconds(audioSrc.clip.length);
        }
    }
}

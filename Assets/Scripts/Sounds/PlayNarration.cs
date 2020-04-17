using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayNarration : MonoBehaviour
{
    [SerializeField]
	public AudioSource narratePlayer;
    [SerializeField]
    public AudioClip[] narrationClips;

    private bool[] isPlayed;

    private void Awake()
    {
        narratePlayer.GetComponent<AudioSource>();
    }
    void Start()
    {
        isPlayed = new bool[narrationClips.Length];
        //Always plays the first clip on entry.
        narratePlayer.Play();
    }

    //Checks which of the clips has been selected, the clip number is defined in the object the player is interacting with.
    public void PlayNextClip(int clipNo)
    {
		/*Debug.Log(!narratePlayer.isPlaying);
        if (!narratePlayer.isPlaying)
        {
			Debug.Log(!narratePlayer.isPlaying);
			if (!isPlayed[clipNo])
            {
                narratePlayer.clip = narrationClips[clipNo];
                narratePlayer.Play();

                isPlayed[clipNo] = true;
            }
            else
            {
                Console.WriteLine("Clip already played.");
            }
        }*/        
    }
}

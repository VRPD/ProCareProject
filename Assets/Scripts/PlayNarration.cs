using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNarration : MonoBehaviour
{
    [SerializeField]
    private AudioSource narratePlayer;
    // Start is called before the first frame update

    private void Awake()
    {
        narratePlayer.GetComponent<AudioSource>();
    }
    void Start()
    {
        narratePlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    
    // Start is called before the first frame update
    public AudioSource soundPlayer;
  
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void PlaySound(AudioClip audio)
    {
        soundPlayer.clip = audio;
        soundPlayer.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    public AudioClip sound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleAudio()
    {
        if (audioSource != null)
        {
            // 関数ToggleAudioが呼ばれたら現在のmuteの値を反転させる
            audioSource.mute = !audioSource.mute;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    public CanvasScaler scaler;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        settingupSize();
    }

    public void ToggleAudio()
    {
        if (audioSource != null)
        {
            // 関数ToggleAudioが呼ばれたら現在のmuteの値を反転させる
            audioSource.mute = !audioSource.mute;
        }
    }


    public void settingupSize()
    {

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;
        scaler.scaleFactor = height / 1080;
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width, height);
 

    }
}

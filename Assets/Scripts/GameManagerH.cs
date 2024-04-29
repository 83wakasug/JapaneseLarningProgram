using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerH : MonoBehaviour
{


    public AudioSource soundPlayer;
    public GameObject Box;
    public ShowTextonButton kana;
    public RectTransform parent;
    public GameObject parentObject;
    public List<AudioClip> sounds;
    public float width;
    public CanvasScaler scaler;



    List<string> hiragana = new List<string>();
 
    public void HiraganaList()
    {

        hiragana.Add("あ");//1
        hiragana.Add("い");//2
        hiragana.Add("う");//3
        hiragana.Add("え");//4
        hiragana.Add("お");//5
        hiragana.Add("か");//6
        hiragana.Add("き");//7
        hiragana.Add("く");//8
        hiragana.Add("け");//9
        hiragana.Add("こ");//10
        hiragana.Add("さ");//11
        hiragana.Add("し");//12
        hiragana.Add("す");//13
        hiragana.Add("せ");//14
        hiragana.Add("そ");//15
        hiragana.Add("た");//16
        hiragana.Add("ち");//17
        hiragana.Add("つ");//18
        hiragana.Add("て");//19
        hiragana.Add("と");//20
        hiragana.Add("な");//21
        hiragana.Add("に");//22
        hiragana.Add("ぬ");//23
        hiragana.Add("ね");//24
        hiragana.Add("の");//25
        hiragana.Add("は");//26
        hiragana.Add("ひ");//27
        hiragana.Add("ふ");//28
        hiragana.Add("へ");//29
        hiragana.Add("ほ");//30
        hiragana.Add("ま");//31
        hiragana.Add("み");//32
        hiragana.Add("む");//33
        hiragana.Add("め");//34
        hiragana.Add("も");//35
        hiragana.Add("や");//36
        hiragana.Add("");
        hiragana.Add("ゆ");//37
        hiragana.Add("");
        hiragana.Add("よ");//38
        hiragana.Add("ら");//39
        hiragana.Add("り");//40
        hiragana.Add("る");//41
        hiragana.Add("れ");//42
        hiragana.Add("ろ");//43
        hiragana.Add("わ");//44
        hiragana.Add("");
        hiragana.Add("");
        hiragana.Add("");
        hiragana.Add("を");//45
        hiragana.Add("ん");//46
        hiragana.Add("");
        hiragana.Add("");
        hiragana.Add("");
        hiragana.Add("");

    }

  


    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        soundPlayer = GetComponent<AudioSource>();
        HiraganaList();

        // Instantiate buttons for each hiragana character

        for (int i = 0; i < hiragana.Count; i++)
        {
            // Create a new button instance based on the Box prefab
            GameObject button = Instantiate(Box, parentObject.GetComponent<RectTransform>());

            // Set the text of the button using the ShowTextonButton component
            button.GetComponent<ShowTextonButton>().setText(hiragana[i]);
            int index = i;

            // Remove all previous click listeners from the button
            button.GetComponent<Button>().onClick.RemoveAllListeners();
            // Add a new click listener to the button
            // This listener calls the OnButtonClick method with the captured index value when the button is clicked
            button.GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(index); });


        }
        // Call the method to set up the size of the UI elements
        settingupSize();
    }

    public void settingupSize() {

        // Get the width and height of the screen resolution
        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;

        // Set the scale factor of the CanvasScaler component based on the screen height

        scaler.scaleFactor = height / 1080;

    
    }

    void OnButtonClick(int index)
    {

        SoundController(index);  // Play sound from soundPlayer
    }
    // Plays the audio clip corresponding to the given index from the sounds list
    public void SoundController(int index)
    {
        // Get the audio clip at the specified index from the sounds list
        AudioClip sound = sounds[index];
        // Call the PlaySound method to play the audio clip
        PlaySound(sound);
    }
 

    public void PlaySound(AudioClip audio)
    {
        // Sets the audio clip of the sound player to the provided audio clip and plays it
        soundPlayer.clip = audio;

        // Play the audio clip
        soundPlayer.Play();
    }
}



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
        soundPlayer = GetComponent<AudioSource>();
        HiraganaList();



        for (int i = 0; i < hiragana.Count; i++)
        {
            GameObject button = Instantiate(Box, parentObject.GetComponent<RectTransform>());
            button.GetComponent<ShowTextonButton>().setText(hiragana[i]);
            int index = i;
            button.GetComponent<Button>().onClick.RemoveAllListeners();
            button.GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(index); });


        }
        settingupSize();
    }

    public void settingupSize() {

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;
        Debug.Log(height);
        scaler.scaleFactor = height / 1080;
        Debug.Log(scaler.scaleFactor);
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width, height);
        Debug.Log(height);

    
    }

    void OnButtonClick(int index)
    {


        SoundController(index);  // SoundPlayerから音声を再生する
    }

    public void SoundController(int index)
    {
        AudioClip sound = sounds[index];
        PlaySound(sound);
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



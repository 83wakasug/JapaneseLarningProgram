﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public static GameController instans;
    public ShowTextonButton Choice1;
    public ShowTextonButton Choice2;
    public ShowTextonButton Choice3;
    public ShowTextonButton Choice4;
    public ShowTextonButton Choice5;
    public ShowTextonButton Hiragana;
    public PanelOpener PanelMessage;
    public SwitchScene swtichSceneMain;
    public SwitchScene switchScheneKatakanaHiraganaGame;
    private string hiragana;
    private Dictionary<string, string> hiraganaKatakanaList;
    private List<string> katakanaList;
    private int index;
    public CanvasScaler scaler;
    // Start is called before the first frame update
    void Start(){

        // Initialize the hiragana and katakana list
        HiraKatanaList();

        // Set up initial values and UI size
        setUpValues();
        settingupSize();


    }

    // Update is called once per frame
    void Update()
    {
        // Reset values and UI size if space key is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {
            setUpValues();
        }
     
    }

    void Awake()
    {
        // Ensure only one instance of GameController exists
        if (GameController.instans != null)
        {
            Destroy(gameObject);
        }
        instans = this;


    }
    
    // Set up the size of UI elements based on screen resolution

    public void settingupSize()
    {

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;
        scaler.scaleFactor = height / 1080;

        RectTransform rect = this.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width, height);


    }

    // Initialize the dictionary containing hiragana and katakana mappings

    public Dictionary<string, string> HiraKatanaList()
    {
        Dictionary<string, string> HiraKata = new Dictionary<string, string>();
        HiraKata.Add("あ", "ア");//1
        HiraKata.Add("い", "イ");//2
        HiraKata.Add("う", "ウ");//3
        HiraKata.Add("え", "エ");//4
        HiraKata.Add("お", "オ");//5
        HiraKata.Add("か", "カ");//6
        HiraKata.Add("き", "キ");//7
        HiraKata.Add("く", "ク");//8
        HiraKata.Add("け", "ケ");//9
        HiraKata.Add("こ", "コ");//10
        HiraKata.Add("さ", "サ");//11
        HiraKata.Add("し", "シ");//12
        HiraKata.Add("す", "ス");//13
        HiraKata.Add("せ", "セ");//14
        HiraKata.Add("そ", "ソ");//15
        HiraKata.Add("た", "タ");//16
        HiraKata.Add("ち", "チ");//17
        HiraKata.Add("つ", "ツ");//18
        HiraKata.Add("て", "テ");//19
        HiraKata.Add("と", "ト");//20
        HiraKata.Add("な", "ナ");//21
        HiraKata.Add("に", "ニ");//22
        HiraKata.Add("ぬ", "ヌ");//23
        HiraKata.Add("ね", "ネ");//24
        HiraKata.Add("の", "ノ");//25
        HiraKata.Add("は", "ハ");//26
        HiraKata.Add("ひ", "ヒ");//27
        HiraKata.Add("ふ", "フ");//28
        HiraKata.Add("へ", "ヘ");//29
        HiraKata.Add("ほ", "ホ");//30
        HiraKata.Add("ま", "マ");//31
        HiraKata.Add("み", "ミ");//32
        HiraKata.Add("む", "ム");//33
        HiraKata.Add("め", "メ");//34
        HiraKata.Add("も", "モ");//35
        HiraKata.Add("や", "ヤ");//36
        HiraKata.Add("ゆ", "ユ");//37
        HiraKata.Add("よ", "ヨ");//38
        HiraKata.Add("ら", "ラ");//39
        HiraKata.Add("り", "リ");//40
        HiraKata.Add("る", "ル");//41
        HiraKata.Add("れ", "レ");//42
        HiraKata.Add("ろ", "ロ");//43
        HiraKata.Add("わ", "ワ");//44
        HiraKata.Add("を", "ヲ");//45
        HiraKata.Add("ん", "ン");//46
        hiraganaKatakanaList = HiraKata;

        return hiraganaKatakanaList;
    }

    public string getRandomHiragana(int count)
    {
        //Get Random Key
        int randomIndex = UnityEngine.Random.Range(0, count);
        string randomKey = hiraganaKatakanaList.Keys.ElementAt(randomIndex);

        hiragana = randomKey;

        return hiragana;
    }

    // Create a list of random katakana characters
    public HashSet<string> setKatakanaList(int count)
    {


        HashSet<string> list = new HashSet<string>();
        while (list.Count < 5)
        {
            //Get Random Key
            int randomIndex = UnityEngine.Random.Range(0,count );
            string randomValue = hiraganaKatakanaList.Values.ElementAt(randomIndex);

            list.Add(randomValue);
        }


       return list;
    }

    // Set the correct answer and choices for the current hiragana character
    public int SetAnswer()
    {
        string answer = hiraganaKatakanaList[hiragana];
        katakanaList = setKatakanaList(hiraganaKatakanaList.Count).ToList();

        int index;

        if (katakanaList.Contains(answer))
        {
            // If the correct answer is included, get its index.
                        index = katakanaList.IndexOf(answer);
        }
        else
        {
            // If the correct answer is not included, set it to a random index.
            int randomIndex = UnityEngine.Random.Range(0, katakanaList.Count);
            katakanaList[randomIndex] = answer;

            index = randomIndex;
        }

     

        return index;
        
    }

    // Set up the values for the UI elements
    public void setUpValues() {
        getRandomHiragana(hiraganaKatakanaList.Count);
        setKatakanaList(hiraganaKatakanaList.Count);
         index=SetAnswer();
        
        Choice1.setText(katakanaList[0]);
        Choice2.setText(katakanaList[1]);
        Choice3.setText(katakanaList[2]);
        Choice4.setText(katakanaList[3]);
        Choice5.setText(katakanaList[4]);
        Hiragana.setText(hiragana);
        PanelMessage.setCorrectIndex(index);
        
    }


}

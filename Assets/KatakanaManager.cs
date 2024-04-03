using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatakanaManager : MonoBehaviour
{

    public AudioClip a;
    public AudioClip i;
    public AudioClip u;
    public AudioClip e;
    public AudioClip o;

    public GameObject Box;
    public ShowTextonButton Showtext;
    List<string> hiragana = new List<string>();
    List<string> katakana= new List<string>();
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
    public void KatakanaList()
    {

        katakana.Add("ア");//1
        katakana.Add("イ");//2
        katakana.Add("ウ");//3
        katakana.Add("エ");//4
        katakana.Add("オ");//5
        katakana.Add("カ");//6
        katakana.Add("キ");//7
        katakana.Add("ク");//8
        katakana.Add("ケ");//9
        katakana.Add("コ");//10
        katakana.Add("サ");//11
        katakana.Add("シ");//12
        katakana.Add("ス");//13
        katakana.Add("セ");//14
        katakana.Add("ソ");//15
        katakana.Add("タ");//16
        katakana.Add("チ");//17
        katakana.Add("ツ");//18
        katakana.Add("テ");//19
        katakana.Add("ト");//20
        katakana.Add("ナ");//21
        katakana.Add("ニ");//22
        katakana.Add("ネ");//24
        katakana.Add("ノ");//25
        katakana.Add("ハ");//26
        katakana.Add("ヒ");//27
        katakana.Add("フ");//28
        katakana.Add("ヘ");//29
        katakana.Add("ホ");//30
        katakana.Add("マ");//31
        katakana.Add("ミ");//32
        katakana.Add("ム");//33
        katakana.Add("メ");//34
        katakana.Add("モ");//35
        katakana.Add("ヤ");//36
        katakana.Add("");
        katakana.Add("ユ");//37
        katakana.Add("");
        katakana.Add("ヨ");//38
        katakana.Add("ラ");//39
        katakana.Add("リ");//40
        katakana.Add("ル");//41
        katakana.Add("レ");//42
        katakana.Add("");
        katakana.Add("");
        katakana.Add("");
        katakana.Add("ヲ");//45
        katakana.Add("ン");//46
        katakana.Add("");
        katakana.Add("");
        katakana.Add("");
        katakana.Add("");

    }

   


    void Start()
    {
        KatakanaList();
        for (int i = 0; i < katakana.Count; i++) {
            GameObject button=Instantiate(Box, transform);
            Showtext.setText(katakana[i]);

        }

    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}

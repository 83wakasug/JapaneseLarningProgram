using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start(){
        HiraKatanaList();
        setUpValues();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            setUpValues();
        }
     
    }

    public void HiraKatanaList()
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
    }

    public void getRandomHiragana()
    {
        //Get Random Key
        int randomIndex = UnityEngine.Random.Range(0, hiraganaKatakanaList.Count);
        string randomKey = hiraganaKatakanaList.Keys.ElementAt(randomIndex);

        hiragana = randomKey;
    }


    public HashSet<string> setKatakanaList()
    {


        HashSet<string> list = new HashSet<string>();
        while (list.Count < 5)
        {
            //Get Random Key
            int randomIndex = UnityEngine.Random.Range(0, hiraganaKatakanaList.Count);
            string randomValue = hiraganaKatakanaList.Values.ElementAt(randomIndex);

            list.Add(randomValue);
        }


       return list;
    }

    public int SetAnswer()
    {
        string answer = hiraganaKatakanaList[hiragana];
        katakanaList = setKatakanaList().ToList();

        int index;

        if (katakanaList.Contains(answer))
        {
            // 正解が含まれている場合、そのインデックスを取得
            index = katakanaList.IndexOf(answer);
        }
        else
        {
            // 正解が含まれていない場合、ランダムなインデックスに正解をセット
            int randomIndex = UnityEngine.Random.Range(0, katakanaList.Count);
            katakanaList[randomIndex] = answer;

            index = randomIndex;
        }

        Debug.Log(index);

        return index;
        
    }

    public void setUpValues() {
        getRandomHiragana();
        setKatakanaList();
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

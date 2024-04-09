using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager4 : MonoBehaviour
{
    public static GameManager4 instance;

    public Boolean answer;
    public TMP_Text hiraganaObject;
    public int score;
    public GameObject fallingObjects;
    public float delayBetweenSpawns = 2f;
    public TMP_Text scoreText;
    private float height;
    public float width;
    public GameController gameContoller;
    Dictionary<string, string> HiraganaKatakanaList;
    string randomHiragana;
    private HashSet<string> katakanaList;
    private List<string> list;
    PanelOpener PanelMessage;
    int index;
 
    public GameObject button;

    void Awake()
    {
        if (GameManager4.instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;

        height = 2 * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

    }
    // Start is called before the first frame update
    void Start()
    {
        print(width);
        score = 0;
        SettingUpKatakana();
      
        StartCoroutine(SpawnKatakana2(1));
        StartCoroutine(SpawnKatakana2(2));
        StartCoroutine(SpawnKatakana2(3));
        StartCoroutine(SpawnKatakana2(0));
        
    }


    Vector2 GetSpawnLocation()
    {
        float x = UnityEngine.Random.Range(-width / 2 + 1, width / 2 - 1);
        Debug.Log(x);
        Debug.Log(width);
        return new Vector2(x, 6.54f);
    }


    
    IEnumerator SpawnKatakana2(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(delayBetweenSpawns, delayBetweenSpawns * 5));
            GameObject obj=Instantiate(fallingObjects, GetSpawnLocation(), Quaternion.identity);
            obj.GetComponent<ShowTextonButton>().setText(list[index]);
            
            
        }
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
    }

    private void SettingUpKatakana() {
        gameContoller = new GameController();
       
         HiraganaKatakanaList=gameContoller.HiraKatanaList();

        randomHiragana = gameContoller.getRandomHiragana(HiraganaKatakanaList.Count);
        Debug.Log(randomHiragana);
        hiraganaObject.text = randomHiragana.ToString();
        Debug.Log(hiraganaObject.text + "text");

        katakanaList = gameContoller.setKatakanaList(HiraganaKatakanaList.Count);
        SetAnswer(randomHiragana, katakanaList);
        // setKatakanaToFallingObject();
      

    }

    

    public int SetAnswer(string rondomHiragana, HashSet<string> katakanaList)
    {
        string answer = HiraganaKatakanaList[randomHiragana];
        
        int index;
        list = katakanaList.ToList();

        if (list.Contains(answer))
        {
            // 正解が含まれている場合、そのインデックスを取得
           index = list.IndexOf(answer);
        }
        else
        {
            // 正解が含まれていない場合、ランダムなインデックスに正解をセット
            int randomIndex = UnityEngine.Random.Range(0, katakanaList.Count);
            list[randomIndex] = answer;

            index = randomIndex;
        }


        return index;

    }



}

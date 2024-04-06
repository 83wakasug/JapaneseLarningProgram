using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager4 : MonoBehaviour
{
    public static GameManager4 instance;

    public int score;
    public List<GameObject> fallingObjects;
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
        StartCoroutine(SpawnKatakana());
    }


    Vector2 GetSpawnLocation()
    {
        float x = UnityEngine.Random.Range(-width / 2 + 1, width / 2 - 1);
        return new Vector2(x, 6.54f);
    }


    IEnumerator SpawnKatakana()
    {
        while (true)
        {
            int index = UnityEngine.Random.Range(0, fallingObjects.Count);
            Instantiate(fallingObjects[index], GetSpawnLocation(), Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
    }

    private void settingUp() {
         HiraganaKatakanaList=gameContoller.HiraKatanaList();

        randomHiragana = gameContoller.getRandomHiragana(HiraganaKatakanaList.Count);
        katakanaList = gameContoller.setKatakanaList(HiraganaKatakanaList.Count);
        SetAnswer(randomHiragana, katakanaList);

        PanelMessage.setCorrectIndex(index);

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

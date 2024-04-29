using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager4 : MonoBehaviour
{
    public static GameManager4 instance;
    public GameObject player;
    public int heartRemain;
    public List<GameObject> Herats;
    private int heart =2;
    public String answer;
    public TMP_Text hiraganaObject;
    public int score;
    public GameObject fallingObjects;
    public float delayBetweenSpawns = 1f;
    public TMP_Text scoreText;
    private float height;
    public float width;     
    public GameController gameContoller;
    Dictionary<string, string> HiraganaKatakanaList;
    string randomHiragana;
    private HashSet<string> katakanaList;
    private List<string> list;
    public GameObject panel;
    int answerIndex;
    public TMP_Text gameOverMessage;
    bool activ;

    public GameObject button;

    void Awake()
    {
        if (GameManager4.instance != null)
        {
           // If an instance exists, destroy this GameObject
            Destroy(gameObject);
        }
       
        // Set this instance as the active instance
        instance = this;

        // Calculate the height and width of the game area based on the camera's orthographic size and aspect ratio
        height = 2 * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

    }
    // Start is called before the first frame update
    void Start()
    {

        activ = true;
        gameContoller = new GameController();
        HiraganaKatakanaList = gameContoller.HiraKatanaList();

        print(width);
        score = 0;
        SettingUpKatakana();

        cloneFallingObject();

    }

    // Get a random spawn location within the game area
    Vector2 GetSpawnLocation()
    {
        float x = UnityEngine.Random.Range(-width / 2 + 1, width / 2 - 1);
       
        return new Vector2(x, 6.54f);
    }



    // Coroutine to spawn falling objects
    IEnumerator SpawnKatakana2()
    {

        int index;

        while (activ)
        {
            index = UnityEngine.Random.Range(0, 5);
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(delayBetweenSpawns, delayBetweenSpawns * 2));

            GameObject obj=Instantiate(fallingObjects, GetSpawnLocation(), Quaternion.identity);
            int count = 0;
            if (count == 4)
            {
                obj.GetComponent<ShowTextonButton>().setText(list[answerIndex]);
                count = 0;
            }
            else
            {
                obj.GetComponent<ShowTextonButton>().setText(list[index]);
            }

            count = count + 1;
           
            if (list[index] == answer) {

                obj.GetComponent<FallingObject>().setTrue();
                
            }
           
        }
    }
    
    // Add points to the game score
    public void AddScore(int point)
    {
        if (heart != 0)
        {
            score += point;
            scoreText.text = score.ToString();
        }
    }

    // Set up a new set of Katakana characters
    public void SettingUpKatakana() {


        randomHiragana = gameContoller.getRandomHiragana(HiraganaKatakanaList.Count);
    
        hiraganaObject.text = randomHiragana.ToString();
 

        katakanaList = gameContoller.setKatakanaList(HiraganaKatakanaList.Count);
        SetAnswer(randomHiragana, katakanaList);
        
      

    }
    // Start spawning falling objects
    public void cloneFallingObject() {
  
        StartCoroutine(SpawnKatakana2());
    }

    // Remove a heart from the game
    public void removeHeart(int heartindex) {
    

            GameObject image = Herats[heartindex];
            image.SetActive(false);
        
    }

    public void gameOver() {

        panel.SetActive(true);
        gameOverMessage.text="ゲームオーバー";
        activ = false;
        
    }

    // Check if the answer provided by the player is correct

    public Boolean judgeAnswer() {
        if (fallingObjects.GetComponent<TMP_Text>().text != answer) {
            if (heart !< 0)
            {
                heart = heart - 1;
            }
            return false;
        }
        return true;
    }

    // Set the correct answer and return its index
    public int SetAnswer(string rondomHiragana, HashSet<string> katakanaList)
    {
         answer = HiraganaKatakanaList[randomHiragana];
        
        int index;
        list = katakanaList.ToList();

        if (list.Contains(answer))
        {
            // 正解が含まれている場合、そのインデックスを取得
            answerIndex = list.IndexOf(answer);
        }
        else
        {
            // 正解が含まれていない場合、ランダムなインデックスに正解をセット
            int randomIndex = UnityEngine.Random.Range(0, katakanaList.Count);
            list[randomIndex] = answer;

            answerIndex = randomIndex;
        }


        return answerIndex;

    }



}

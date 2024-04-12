using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform transform1;
    private SpriteRenderer sr;
    public float speed;
    private float minX;
    private float maxX;


    public int Countdown = 3;
    public float timeVisible = 0.2f;
    public float timeInvisible = 0.2f;
    public float blinkFor = 1f;
    public bool startState = true;
    public bool endState = true;
    private int heart = 2;

    // Start is called before the first frame update
    void Start()
    {

        transform1 = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        minX = -GameManager4.instance.width / 2 + sr.size.x / 2;
        maxX = GameManager4.instance.width / 2 - sr.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {
            if (transform.position.x >= minX)
            {
                transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if (Input.GetKey("right"))
        {
            if (transform.position.x <= maxX)
            {
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                GetComponent<SpriteRenderer>().flipX = true;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.GetComponent<FallingObject>().answer)
        {
            GameManager4.instance.AddScore(col.gameObject.GetComponent<FallingObject>().point);
            GameManager4.instance.SettingUpKatakana();
            

        }
        else {
            GameManager4.instance.removeHeart(heart);
            StartCoroutine(blink());
            this.heart = heart - 1;
            if (heart < 0) {
                GameManager4.instance.gameOver();
            }

        }
        Destroy(col.gameObject);
    }


    //https://forum.unity.com/threads/how-do-you-make-objects-flash.101656/
    IEnumerator blink()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = startState;


        var whenAreWeDone = Time.time + blinkFor;

        while (Time.time < whenAreWeDone)
        {
            if (startState)
            {
                renderer.enabled = false;
                yield return new WaitForSeconds(timeInvisible);
                renderer.enabled = true;
                yield return new WaitForSeconds(timeVisible);
            }
            else
            {
                renderer.enabled = true;
                yield return new WaitForSeconds(timeVisible);
                renderer.enabled = false;
                yield return new WaitForSeconds(timeInvisible);
            }
        }
        renderer.enabled = endState;


    }
}

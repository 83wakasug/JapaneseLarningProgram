using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform transform1;
    private SpriteRenderer sr;
    private float speed =10F;
    private float minX;
    private float maxX;
    private float screenWidth;


    public int Countdown = 3;
    public float timeVisible = 0.2f;
    public float timeInvisible = 0.2f;
    public float blinkFor = 1f;
    public bool startState = true;
    public bool endState = true;
    private int heart = 2;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        transform1 = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        screenWidth = Screen.width;
        minX = -GameManager4.instance.width / 2 + sr.size.x / 2;
        maxX = GameManager4.instance.width / 2 - sr.size.x / 2;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        
        float speed2 = speed * (screenWidth / 1920);
        Debug.Log(speed2+"speed2");
        
        // Move the GameObject to the left if the left arrow key is pressed
        if (Input.GetKey("left"))
        {

            if (transform.position.x >= minX)
            {
                // Move the GameObject to the left by subtracting the speed from its x position
                rb.AddForce(new Vector2(-speed2, 0));
               

                // Flip the GameObject's sprite horizontally
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else {

                transform.position = new Vector2(minX, transform.position.y);

                rb.velocity = Vector2.zero;

            }
        }else if (Input.GetKey("right"))
        {

            if (transform.position.x <= maxX)
            {
                rb.AddForce(new Vector2(speed2, 0));
                
                GetComponent<SpriteRenderer>().flipX = true;

            }
            else
            {
                transform.position = new Vector2(maxX, transform.position.y);
                rb.velocity = Vector2.zero;

            }
        }
        else{ 
            
           rb.velocity = Vector2.zero;

         }
    }
    // OnTriggerEnter2D is called when the GameObject collides with another Collider2D

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the collided object has a FallingObject component with the answer property set to true

        if (col.gameObject.GetComponent<FallingObject>().answer)
        { 
            // Add points to the game score
            GameManager4.instance.AddScore(col.gameObject.GetComponent<FallingObject>().point);
            // Set up a new falling object
            GameManager4.instance.SettingUpKatakana();
            

        }
        else {
            // Remove a heart from the game
            if (heart >= 0)
            {
                GameManager4.instance.removeHeart(heart);
            }
            // Initiate a blinking effect
            StartCoroutine(blink());
            this.heart = heart - 1;
            if (heart < 0) {
                GameManager4.instance.gameOver();
            }

        }

        // Destroy the collided object
        Destroy(col.gameObject);
    }



    //Rad 96 till 124 Hämtade code från https://forum.unity.com/threads/how-do-you-make-objects-flash.101656/

    // Coroutine to make the GameObject blink
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

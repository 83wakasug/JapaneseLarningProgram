using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform transform1;
    private SpriteRenderer sr;
    public float speed;
    private float minX;
    private float maxX;

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
            }
        }

        if (Input.GetKey("right"))
        {
            if (transform.position.x <= maxX)
            {
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameManager4.instance.AddScore(col.gameObject.GetComponent<FallingObject>().point);
        Destroy(col.gameObject);
    }
}

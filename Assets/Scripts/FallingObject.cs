using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private float endY = -10f;
    private Transform transform1;
    private SpriteRenderer sr;
    public int point;
    public Boolean answer;
    public float speed = 0.02f;
    Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        transform1 = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        endPos = new Vector2(transform.position.x, endY);
        StartCoroutine(LerpPosition(endPos, speed));
    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        Destroy(gameObject);
    }

}

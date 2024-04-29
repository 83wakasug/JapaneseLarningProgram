using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private float endY = -10f; // The Y-coordinate of the end position where the object gets destroyed
    private Transform transform1; // A reference to the object's Transform component
    private SpriteRenderer sr; // A reference to the object's SpriteRenderer component
    public int point; // The points represented by the object
    public bool answer; // Whether the object represents the correct answer
    public float speed = 1f; // The speed at which the object falls
    public int heart; // The number of hearts represented by the object
    Vector2 endPos; // The end position where the object falls to

    // Start is called before the first frame update
    void Start()
    {
        // Get references to the Transform and SpriteRenderer components
        transform1 = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();

        // Calculate the end position based on the object's current position and endY
        endPos = new Vector2(transform.position.x, endY);

        // Start a coroutine to interpolate the object's position
        StartCoroutine(LerpPosition(endPos, speed));
    }

    // A coroutine to interpolate the object's position to targetPosition over a certain duration
    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0; // The time elapsed since the start of interpolation
        Vector2 startPosition = transform.position; // The object's starting position

        // Interpolate the object's position over the duration
        while (time < duration)
        {
            // Use Lerp to move the object's position from startPosition to targetPosition
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);

            // Update the elapsed time
            time += Time.deltaTime;

            // Wait until the next frame before the next iteration of interpolation
            yield return null;
        }

        // Set the object's position to targetPosition when interpolation is complete
        transform.position = targetPosition;

        // Destroy the object when it reaches the end position
        Destroy(gameObject);
    }

    // A method to set 'answer' to true (used for marking the correct answer)
    public void setTrue()
    {
        answer = true;
    }


}

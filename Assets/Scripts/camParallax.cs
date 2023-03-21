using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camParallax : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public GameObject floor;
    public GameObject wall;
    public GameObject[] battler;
    public GameObject[] enemy;
    public float flipXPosition = 9.0f; // The x position threshold for flipping the sprite
public bool flipOnGreater = true;  // If true, flip when the x position is greater than the threshold, otherwise, flip when it's less than the threshold

    void Update()
    {
        float rotation = 0.0f;
        float vertRotation = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = -rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation = rotationSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            vertRotation = -rotationSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertRotation = rotationSpeed * Time.deltaTime;
        }

        floor.transform.Rotate(0, 0, rotation);
        wall.gameObject.transform.Translate(-rotation, 0, 0);
        gameObject.transform.Rotate(vertRotation, 0, 0);
        foreach(var i in battler)
        {
            SpriteRenderer spriteRenderer = i.gameObject.GetComponent<SpriteRenderer>();
            i.gameObject.transform.Translate(rotation * 5, 0, 0);
            if(i.gameObject.transform.position.x > enemy[0].transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else { spriteRenderer.flipX = false; }
        }
        foreach(var i in enemy)
        {
            SpriteRenderer spriteRenderer = i.gameObject.GetComponent<SpriteRenderer>();
            i.gameObject.transform.Translate(-rotation * 2, vertRotation * 7, 0);
            if(i.gameObject.transform.position.x > battler[0].transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else { spriteRenderer.flipX = false; }
        }
    }
}
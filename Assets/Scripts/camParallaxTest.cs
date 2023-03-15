using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camParallaxTest : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public GameObject floor;
    public GameObject wall;

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
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float rotateSpeed = 1f;
    public bool rotatingLeft = false;
    public bool rotatingRight = false;
    public bool lookingAtMonster = false;
    private bool initRotate = false;
    public bool playerDead = false;
    private int yRotation;
    public int station;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead == true)
        {
            gameOver.SetActive(true);
        }
    }

    void LateUpdate()
    {
        yRotation = (int)transform.eulerAngles.y;

        if (Input.GetKey(KeyCode.D))
        {
            rotatingLeft = true;
            rotatingRight = false;
            initRotate = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotatingRight = true;
            rotatingLeft = false;
            initRotate = true;
        }

        if (station == 4)
        {
            station = 0;
        }

        if (station == -1)
        {
            station = 3;
        }

        if (station == 1)
        {
            lookingAtMonster = true;
        }

        else
        {
            lookingAtMonster = false;
        }

        if (rotatingLeft)
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }

        if (rotatingRight)
        {
            transform.Rotate(Vector3.down, rotateSpeed);
        }

        if (yRotation  == 0)
        {
            StopRotation();
            station = 0;
        }

        if (yRotation == 90)
        {
            StopRotation();
            station = 1;
        }

        if (yRotation == 180)
        {
            StopRotation();
            station = 2;
        }

        if (yRotation == 270)
        {
            StopRotation();
            station = 3;
        }
    }

    void StopRotation()
    {
        rotatingLeft = false;
        rotatingRight = false;
    }
}

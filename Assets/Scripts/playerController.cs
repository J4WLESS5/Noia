using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float rotateSpeed = 1f;
    private bool rotatingLeft = false;
    private bool rotatingRight = false;
    private bool initRotate = false;
    private int yRotation;
    public int station;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yRotation = (int)transform.eulerAngles.y;

        if (Input.GetKey(KeyCode.D))
        {
            rotatingLeft = true;
            rotatingRight = false;
            initRotate = true;
            station = station - 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotatingRight = true;
            rotatingLeft = false;
            initRotate = true;
            station = station + 1;
        }

        if (station == -2)
        {
            station = 2;
        }

        if (rotatingLeft)
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }

        if (rotatingRight)
        {
            transform.Rotate(Vector3.down, rotateSpeed);
        }
    }

    void LateUpdate()
    {
        if (yRotation  == 0)
        {
            StopRotation();
        }

        if (yRotation == 90)
        {
            StopRotation();
        }

        if (yRotation == 180)
        {
            StopRotation();
        }

        if (yRotation == 270)
        {
            StopRotation();
        }
    }

    void StopRotation()
    {
        rotatingLeft = false;
        rotatingRight = false;
    }
}

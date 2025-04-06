using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float rotateSpeed = 0.5f;
    public bool rotatingLeft = false;
    public bool rotatingRight = false;
    public bool initRotate = false;
    public int yRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yRotation = (int)transform.eulerAngles.y;

        if (Input.GetKeyDown(KeyCode.D))
        {
            rotatingLeft = true;
            initRotate = true;
        }

        if (rotatingLeft == true)
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }
    }

    void LateUpdate()
    {
        if (yRotation == 0)
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
        if (initRotate == true)
        {

            Debug.Log("stop rotate");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightController : MonoBehaviour
{
    public bool flashlightToggle = true;
    public GameObject flashlightObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlightToggle == true)
            {
                flashlightToggle = false;
                flashlightObject.SetActive(flashlightToggle);
            }
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (flashlightToggle == false)
            {
                flashlightToggle = true;
                flashlightObject.SetActive(flashlightToggle);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTestLight : MonoBehaviour
{
    private GameObject testLight;

    // Start is called before the first frame update
    void Start()
    {
        testLight = GameObject.Find("Test Light");
        testLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

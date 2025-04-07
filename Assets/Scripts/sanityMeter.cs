using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sanityMeter : MonoBehaviour
{
    public float sanityFloat = 100;
    public float sanityDrainRate = 0.001f;
    public int sanityInt;
    public TMP_Text sanityText;
    public flashlightController flashlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sanityText.SetText("Sanity: " + sanityInt + "%");
        sanityInt = (int)sanityFloat;
        sanityFloat = sanityFloat - sanityDrainRate;
        if (flashlight.flashlightToggle == false)
        {
            sanityDrainRate = 0.01f;
        }

        else
        {
            sanityDrainRate = 0.001f;
        }
    }
}

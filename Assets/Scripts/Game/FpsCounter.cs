using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    public TMP_Text FpsText;
    private float pollingTime = 1f;
    private float time;
    private int FrameCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        FrameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(FrameCount/time);
            FpsText.text = "FPS: " + frameRate.ToString();
            time -= pollingTime;
            FrameCount = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume volume;
    public PlayerController player;
    private DepthOfField DOF;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out DOF);
        DOF.focusDistance.overrideState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.station == 0)
        {
            DOF.focusDistance.value = 1.23f;
        }

        if (player.station == 3)
        {
            DOF.focusDistance.value = 2;
        }

        if (player.station == 1)
        {
            DOF.focusDistance.value = 4;
        }
    }
}

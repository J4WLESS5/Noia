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
    private ChromaticAberration CA;
    private Grain G;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out DOF);
        volume.profile.TryGetSettings(out CA);
        volume.profile.TryGetSettings(out G);
        CA.intensity.overrideState = true;
        G.intensity.overrideState = true;
        DOF.focusDistance.overrideState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.station == 0)
        {
            DOF.focusDistance.value = 1.23f;
            CA.intensity.value = 0.5f;
        }

        if (player.station == 3)
        {
            DOF.focusDistance.value = 2;
            CA.intensity.value = 0.5f;
        }

        if (player.station == 1)
        {
            DOF.focusDistance.value = 4;
            CA.intensity.value = 0.5f;
        }

        if (player.station == 5)
        {
            DOF.focusDistance.value = 4.3f;
            CA.intensity.value = 0;
        }
    }
}

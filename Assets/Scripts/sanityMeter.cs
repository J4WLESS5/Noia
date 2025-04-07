using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SanityMeter : MonoBehaviour
{
    public float sanityFloat = 100;
    public float sanityDrainRate = 0.001f;
    public int sanityInt;
    public TMP_Text sanityText;
    public FlashlightController flashlight;
    public MonsterController monster;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sanityText.SetText("Sanity: " + sanityInt + "%");

        sanityInt = (int)sanityFloat;

        if (player.playerDead == false)
        {
            sanityFloat = sanityFloat - sanityDrainRate;
        }

        if (flashlight.flashlightToggle == false)
        {
            sanityDrainRate = 0.01f;
        }

        else
        {
            sanityDrainRate = 0.001f;
        }

        if (monster.phase == 4 && player.lookingAtMonster == true)
        {
            sanityDrainRate = sanityDrainRate + 0.1f;
        }

        else
        {
            sanityDrainRate = sanityDrainRate;
        }

        if (sanityInt == 0)
        {
            player.playerDead = true;
            Debug.Log("oh no you dead you got too silly oh nooooo :((((");
        }
    }
}

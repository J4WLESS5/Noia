using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemTransfer : MonoBehaviour
{
    public PlayerController player;
    public GameObject monitorPrompt;
    public bool lookingAtMonitor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.station == 3)
        {
            monitorPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                lookingAtMonitor = true;
                player.station = 5;
                monitorPrompt.SetActive(false);
            }
        }

        else
        {
            monitorPrompt.SetActive(false);
        }

        if (player.station == 5)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                lookingAtMonitor = false;
                player.station = 3;
            }
        }

        if (player.rotatingLeft)
        {
            monitorPrompt.SetActive(false);
        }

        if (player.rotatingRight)
        {
            monitorPrompt.SetActive(false);
        }
    }
}

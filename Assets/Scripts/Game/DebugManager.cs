using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public bool debug = false;
    public float debugTimer = 3;
    public int debugTimerInt;
    public GameObject debugDisplay;
    public MonsterController monster;
    public Generator generator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            debug = true;
            debugDisplay.SetActive(true);
        }

        if (debug == true)
        {
            debugTimer = debugTimer - 0.01f;
            if (Input.GetKeyDown(KeyCode.RightAlt))
            {
                monster.phase = monster.phase + 1;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                generator.generatorOn = true;
                generator.initGenerator = true;
            }
        }

        debugTimerInt = (int)debugTimer;

        if (debugTimerInt < 0)
        {
            debugDisplay.SetActive(false);
        }
    }
}

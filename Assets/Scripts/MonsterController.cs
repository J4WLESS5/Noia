using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int phase;
    public int phaseTimer;
    public int phaseChance;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseTimer == 30)
        {
            phaseChance = Random.Range(0, 11);
            phaseTimer = 0;
        }

        if (player.lookingAtMonster == false && phaseChance == 10)
        {
            phase = phase + 1;
            phaseChance = 0;
        }

        if (phase == 1)
        {
            transform.position = new Vector3(18, 1.26f, 0);
        }

        if (phase == 2)
        {
            transform.position = new Vector3(13, 1.26f, 0);
        }

        if (phase == 3)
        {
            transform.position = new Vector3(13, -1.5f, 0);
        }

        if (phase == 4)
        {
            transform.position = new Vector3(3.42f, 1.26f, 0);
        }

        if (phase == 5)
        {
            Debug.Log("oh no you got eaten by the monster you dead now oh nooooo");
            player.playerDead = true;
            transform.position = new Vector3(3.42f, -1.5f, 0);
            phase = 0;
        }
    }

    void FixedUpdate()
    {
        phaseTimer = phaseTimer + 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int phase;
    public int phaseTimer;
    public int phaseChance;
    public float jumpscareTimer;
    public bool jumpscare = false;
    public bool jumpscareMove = false;
    public Vector3 jumpscarePos;
    public AudioSource monsterSound;
    public Animator monsterAnimator;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        monsterSound = GetComponent<AudioSource>();
        jumpscarePos = transform.position;
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
            transform.position = new Vector3(18, 0.06f, 0);
        }

        if (phase == 2)
        {
            transform.position = new Vector3(13, 0.06f, 0);
        }

        if (phase == 3)
        {
            transform.position = new Vector3(13, -1.5f, 0);
        }

        if (phase == 4)
        {
            transform.position = new Vector3(3.42f, 0.06f, 0);
        }

        if (phase == 5)
        {
            Debug.Log("oh no you got eaten by the monster you dead now oh nooooo");
            player.playerDead = true;
            transform.position = jumpscarePos;
            phase = 0;
            monsterAnimator.SetBool("Jumpscare", true);
            jumpscareMove = true;
        }

        if (phase == 0 && jumpscareMove == true)
        {
            jumpscareTimer = jumpscareTimer - 0.01f;
        }

        if (jumpscareTimer < 0)
        {
            jumpscare = true;
        }
    }

    void FixedUpdate()
    {
        phaseTimer = phaseTimer + 1;
    }
}

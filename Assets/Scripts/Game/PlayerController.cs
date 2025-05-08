using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float rotateSpeed = 1f;
    public float endGameTimer;
    public bool endGame;
    public bool rotatingLeft = false;
    public bool rotatingRight = false;
    public bool lookingAtMonster = false;
    public bool playerDead = false;
    private int yRotation;
    public int station;
    public Vector3 scarePos;
    public MonsterController monster;
    public Generator generator;
    public GameObject gameOver;
    public GameObject flashGif;
    public Animator flashAnimator;
    public AudioClip jumpscareSound;
    


    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
        scarePos = new Vector3(-8.047f, 1.694f, -0.205f);
        flashGif = GameObject.Find("flash-gif");
        flashAnimator = flashGif.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead == true)
        {
            gameOver.SetActive(true);
        }

        if (monster.jumpscare == true)
        {
            transform.position = scarePos;
            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            monster.monsterSound.PlayOneShot(jumpscareSound);
            endGameTimer = endGameTimer - 0.01f;
        }

        if (endGameTimer < 0 && endGame == false)
        {
            endGame = true;
            flashGif.transform.position = new Vector3(-8f, 1.5f, 0f);
            flashAnimator.SetBool("Flash", true);
        }
    }

    void LateUpdate()
    {
        yRotation = (int)transform.eulerAngles.y;

        if (Input.GetKey(KeyCode.D) && generator.generatorOn == true)
        {
            rotatingLeft = true;
            rotatingRight = false;
        }

        if (Input.GetKey(KeyCode.A) && generator.generatorOn == true)
        {
            rotatingRight = true;
            rotatingLeft = false;
        }

        if (station == 4)
        {
            station = 0;
        }

        if (station == -1)
        {
            station = 3;
        }

        if (station == 1)
        {
            lookingAtMonster = true;
        }

        else
        {
            lookingAtMonster = false;
        }

        if (station == 5 && monster.jumpscare == false)
        {
            gameObject.transform.position = new Vector3(-0.5f, 1.26f, 0f);
        }

        else if (monster.jumpscare == false)
        {
            gameObject.transform.position = new Vector3(0f, 1.26f, 0f);
        }

        if (rotatingLeft)
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }

        if (rotatingRight)
        {
            transform.Rotate(Vector3.down, rotateSpeed);
        }

        if (yRotation  == 0)
        {
            StopRotation();
            station = 0;
        }

        if (yRotation == 90)
        {
            StopRotation();
            station = 1;
        }

        if (yRotation == 180)
        {
            StopRotation();
            station = 2;
        }

        if (yRotation == 270)
        {
            StopRotation();
            station = 3;
        }
    }

    void StopRotation()
    {
        rotatingLeft = false;
        rotatingRight = false;
    }
}

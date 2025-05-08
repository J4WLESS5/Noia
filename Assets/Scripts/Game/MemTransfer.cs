using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemTransfer : MonoBehaviour
{
    public PlayerController player;
    public GameObject monitorPrompt;
    public GameObject errorMessage;
    public GameObject transferMessage;
    public Generator generator;
    public AudioSource monitorAudio;
    public bool lookingAtMonitor;
    public bool monitorError;
    public int errorTimer;
    public int errorChance;

    // Start is called before the first frame update
    void Start()
    {
        monitorAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        errorTimer = errorTimer + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (errorTimer == 10)
        {
            errorChance = Random.Range(0, 11);
            errorTimer = 0;
        }

        if (errorChance == 10)
        {
            monitorError = true;
        }

        if (monitorError == true)
        {
            Debug.Log("Tranfer Error!");
            if (generator.gameStart == true)
            {
                if (!monitorAudio.isPlaying)
                {
                    monitorAudio.Play();
                }

                errorMessage.SetActive(true);
                transferMessage.SetActive(false);

                if (Input.GetKey(KeyCode.R))
                {
                    monitorError = !monitorError;
                }
            }
        }

        else
        {
            errorMessage.SetActive(false);
            transferMessage.SetActive(true);
            monitorAudio.Stop();
        }

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

            if (generator.gameWin == true && monitorError == false)
            {
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("Post-Game");
                }
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

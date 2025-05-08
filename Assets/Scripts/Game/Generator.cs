using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmoothShakeFree;
using Unity.VisualScripting;
using TMPro;

public class Generator : MonoBehaviour, IInteractable
{
    public GameObject Monster;
    public GameObject flashlightObject;
    public GameObject monitorLight;
    public GameObject managers;
    public GameObject flashlightText;
    public GameObject sanityText;
    public GameObject initText;
    public TMP_Text transferText;
    public SmoothShake shake;
    public SmoothShake generatorShake;
    public FlashlightController flashlight;
    public MemTransfer monitor;
    public AudioSource audioSource;
    public AudioSource ambienceAudioSource;
    public AudioClip onSound;
    public AudioClip generatorStartup;
    public AudioClip generatorOnSound;
    public int gameTime = 5000;
    public int generatorInput = 3;
    public bool gameWin= false;
    public bool initGenerator = true;
    public bool generatorOn = false;
    public bool ambiencePlaying = false;
    public bool gameStart = false;

    public void Interact()
    {
        if (generatorOn == false)
        {
            generatorInput = generatorInput - 1;
            shake.StartShake();
            audioSource.PlayOneShot(generatorStartup);
        }

        else if (generatorOn == true && initGenerator == true)
        {
            managers.SetActive(true);
            Debug.Log("interact");
            flashlightText.SetActive(true);
            sanityText.SetActive(true);
            initText.SetActive(false);
            Monster.SetActive(true);
            flashlight.flashlightToggle = true;
            flashlightObject.SetActive(true);
            monitorLight.SetActive(true);
            audioSource.PlayOneShot(onSound);
            audioSource.PlayOneShot(generatorOnSound);
            initGenerator = false;
            gameStart = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWin == true)
        {
            flashlightText.SetActive(false);
            sanityText.SetActive(false);
            Monster.SetActive(false);
            transferText.SetText("Transfer completed! Press R to view files");
        }

        if (generatorInput == 0)
        {
            generatorOn = true;
        }

        if (generatorOn == true)
        {
            generatorShake.StartShake();
            if (!audioSource.isPlaying && ambiencePlaying == false)
            {
                ambienceAudioSource.Play();
                ambiencePlaying = true;
            }
        }

        if (gameTime == 0)
        {
            gameWin = true;
        }
    }

    public void FixedUpdate()
    {
        if (gameStart == true && monitor.monitorError == false)
        {
            gameTime = gameTime - 1;
        }
    }
}

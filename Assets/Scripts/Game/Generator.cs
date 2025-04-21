using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmoothShakeFree;

public class Generator : MonoBehaviour, IInteractable
{
    public GameObject Monster;
    public GameObject flashlightObject;
    public GameObject managers;
    public GameObject flashlightText;
    public GameObject sanityText;
    public GameObject initText;
    public SmoothShake shake;
    public FlashlightController flashlight;
    public AudioSource audioSource;
    public AudioSource ambienceAudioSource;
    public AudioClip onSound;
    public AudioClip generatorStartup;
    public AudioClip generatorOnSound;
    public int generatorInput = 3;
    public bool initGenerator = true;
    public bool generatorOn = false;
    public bool ambiencePlaying = false;

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
            audioSource.PlayOneShot(onSound);
            audioSource.PlayOneShot(generatorOnSound);
            initGenerator = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generatorInput == 0)
        {
            generatorOn = true;
        }

        if (generatorOn == true)
        {
            if (!audioSource.isPlaying && ambiencePlaying == false)
            {
                ambienceAudioSource.Play();
                ambiencePlaying = true;
            }
        }
    }
}

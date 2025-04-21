using UnityEngine;
using TMPro;

public class FlashlightController : MonoBehaviour
{
    public bool flashlightToggle = true;
    public bool flashlightDead = false;
    public int batteryInt;
    public float batteryFloat = 100;
    public float batteryDrainRate = 0.01f;
    public float batteryRechargeRate = 0.1f;
    public TMP_Text batteryText;
    public GameObject flashlightObject;
    private AudioSource audioSource;
    public AudioClip onSound;
    public AudioClip offSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        batteryInt = (int)batteryFloat;
        batteryText.SetText("Flashlight Battery: " + batteryInt + "%");

        if (Input.GetKeyDown(KeyCode.F) && flashlightDead == false)
        {
            flashlightToggle = !flashlightToggle;

            flashlightObject.SetActive(flashlightToggle);

            if (flashlightToggle == true)
            {
                audioSource.PlayOneShot(onSound);
            }

            if (flashlightToggle == false)
            {
                audioSource.PlayOneShot(offSound);
            }
        }

        if (flashlightToggle == true && batteryInt > 0)
        {
            batteryFloat = batteryFloat - batteryDrainRate;
        }

        if (flashlightToggle == false && batteryInt < 100)
        {
            batteryFloat = batteryFloat + batteryRechargeRate;
        }

        if (batteryInt <= 0)
        {
            flashlightToggle = false;
            flashlightObject.SetActive(flashlightToggle);
            flashlightDead = true;
        }

        if (batteryInt >= 100)
        {
            flashlightDead = false;
        }
    }
}

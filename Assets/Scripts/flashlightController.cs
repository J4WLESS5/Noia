using UnityEngine;

public class flashlightController : MonoBehaviour
{
    public bool flashlightToggle = true;
    public GameObject flashlightObject;
    public float battery = 100;
    public float batteryDrainRate = 0.01f;
    public float batteryRechargeRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightToggle = !flashlightToggle;
            flashlightObject.SetActive(flashlightToggle);
        }

        if (flashlightToggle == true && battery > 0)
        {
            battery = battery - batteryDrainRate;
        }

        if (flashlightToggle == false && battery < 100)
        {
            battery = battery + batteryRechargeRate;
        }
    }
}

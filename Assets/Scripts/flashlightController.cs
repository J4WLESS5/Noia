using UnityEngine;

public class flashlightController : MonoBehaviour
{
    public bool flashlightToggle = true;
    public GameObject flashlightObject;

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPos : MonoBehaviour
{
    //attach the player to this, obviously
    public GameObject player;

    //set a likeable sensitivity, then set to private
    public float mouseSensitivity = 2;
    private float verticalRotation;
    private float xInput;
    private float yInput;
    bool visibleCursor = false;

    // Start is called before the first frame update
    void Start()
    {
        //sets the cursor to be invisible during gameplay
        Cursor.visible = visibleCursor;

        //locks cursor position (not mouse position! cursor does not equal mouse)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //sets the position of the camera equal to the player. Not needed, but set as a precaution
        transform.position = player.transform.position;

        //sets xInput to the X position of the mouse, times the mouse sensitivity
        xInput = Input.GetAxis("Mouse X") * mouseSensitivity;

        //sets yInput to the Y position of the mouse, times the mouse sensitivity
        yInput = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //sets verticalRotation to the negative of yInput, in order to allow the camera to move properly
        verticalRotation -= yInput;

        //prevents the player from looking too far up or down
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        //rotates the camera based on the value of verticalRotation
        transform.localEulerAngles = Vector3.right * verticalRotation;

        //rotates the player based on the value of xInput
        player.transform.Rotate(Vector3.up * xInput);
    }
}

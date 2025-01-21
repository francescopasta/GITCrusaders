using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSquareRestriction : MonoBehaviour
{
    public Transform player;
    [Space(5)]
    public float minYposition;
    public float maxYposition;
    public float minXposition;
    public float maxXposition;
    [Space(5)]
    public float rotationSpeed;

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Start()
    {
        //Horizontal rotation is based on the player's initial rotation
        horizontalRotation = player.eulerAngles.y;

        Cursor.lockState = CursorLockMode.Locked; //Lock the cursor to the center of the screen
    }

    void LateUpdate()
    {
        //Mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        //Calculate horizontal rotation
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, minXposition, maxXposition);

        //Apply horizontal rotation to the player
        player.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        //Calculate vertical rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minYposition, maxYposition);

        //Apply vertical rotation to the camera (local rotation)
        transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
    }
}

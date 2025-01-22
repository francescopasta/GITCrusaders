using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaceholderScript : MonoBehaviour
{
    public Transform player;

    private float rotationChangeSpeed = 15f;
    private float moveSmoothness = 5f;
    private float rotateSmoothness = 5f;
    private float initialRotationOffset = 45f;
    private float heightYoffset = 35f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        targetPosition = transform.position;

        //Apply the initial rotation offset
        targetRotation = Quaternion.Euler(0, initialRotationOffset, 0);
        transform.rotation = targetRotation;

        if (player == null)
        {
            Debug.LogError("Player not assigned");
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float playerY = player.position.y;

        //Position change speed based on the player's Y position
        float positionChangeSpeed = Mathf.Abs(playerY) * 0.1f;

        //Adjust the Y position of the camera based on the player's Y position
        targetPosition.y = Mathf.Lerp(targetPosition.y, playerY + heightYoffset, Time.deltaTime * moveSmoothness);

        //Update target values if a key is held
        if (Input.GetKey(KeyCode.D))
        {
            ChangeObjectValues(Time.deltaTime * positionChangeSpeed, -Time.deltaTime * rotationChangeSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ChangeObjectValues(-Time.deltaTime * positionChangeSpeed, Time.deltaTime * rotationChangeSpeed);
        }

        //Move towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSmoothness);

        //Rotate the camera based on the player's X position
        RotateCameraBasedOnPlayerPosition();
    }

    //Function to update the target position and rotation
    void ChangeObjectValues(float changedPosition, float changedRotation)
    {
        //Update the target position
        targetPosition += new Vector3(0, changedPosition, 0);

        //Update the target rotation
        targetRotation = Quaternion.Euler(
            targetRotation.eulerAngles.x,
            targetRotation.eulerAngles.y + changedRotation,
            targetRotation.eulerAngles.z
        );
    }

    //Function to rotate the camera based on the player's position
    void RotateCameraBasedOnPlayerPosition()
    {
        //Calculate the direction the camera should face based on the player's X position relative to the camera
        float angleToPlayer = Mathf.Atan2(player.position.x - transform.position.x, player.position.z - transform.position.z) * Mathf.Rad2Deg;

        //Rotate the camera towards the player along the Y axis
        Quaternion targetRotation = Quaternion.Euler(0, angleToPlayer + initialRotationOffset, 0);  //Add the offset
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSmoothness);
    }
}

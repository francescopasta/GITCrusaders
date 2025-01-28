using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushMechanic : MonoBehaviour
{
    public PlayerScript playerScript;
    public HuggingPlayer huggerScript;
    public Animator playerAnimator;
    public float totalMashTimer;
    public float currentMashTimer;
    public int buttonMashRequirement = 0;
    public int totalMashRequirement;
    public bool pushing;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && huggerScript.attachedHuggers > 0)
        {
            buttonMashRequirement++;
            pushing = true;
            playerAnimator.SetTrigger("isUsingPush");
        }

    }
    private void FixedUpdate()
    {
        if (pushing)
        {
            if (currentMashTimer < totalMashTimer)
            {
                currentMashTimer += Time.deltaTime;

                // Check if the button mash requirement is met
                if (buttonMashRequirement == totalMashRequirement)
                {
                    huggerScript.DeactivateEnemies(0);
                    buttonMashRequirement = 0;
                    currentMashTimer = 0;
                    pushing = false;
                }
            }
            if (currentMashTimer >= totalMashTimer && buttonMashRequirement < totalMashRequirement)
            {
                pushing = false;
                buttonMashRequirement = 0;
                currentMashTimer = 0;
            }
        }
    }

}

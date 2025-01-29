using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public AudioSource pushAudio;
    public bool audioPlaying;
    public AudioSource huggersPushedOffAudio;
    // Update is called once per frame
    public GameObject EKeyPress;
    public GameObject EKeyOpen;
    public GameObject Bar1;
    public GameObject Bar2;
    public Image Bar1Fill;
    public Image Bar2Fill;
    // Update is called once per frame
    private void Start()
    {
        SetUI(false);
        EKeyOpen.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && huggerScript.attachedHuggers > 0)
        {
            if (buttonMashRequirement % 2 == 0)
            {
                pushAudio.Play();
            }
            buttonMashRequirement++;
            pushing = true;
            playerAnimator.SetTrigger("isUsingPush");
            EKeyOpen.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.E) && pushing)
        {
            EKeyOpen.SetActive(true);
        }
        if (huggerScript.attachedHuggers > 0)
        {

            SetUI(true);
        }

    }
    private void LateUpdate()
    {
        if (pushing)
        {
            Bar1Fill.fillAmount = (float)buttonMashRequirement / totalMashRequirement;
            Bar2Fill.fillAmount = (float)buttonMashRequirement / totalMashRequirement;
        }
        else
        {
            Bar1Fill.fillAmount = 0;
            Bar2Fill.fillAmount = 0;
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
                    huggersPushedOffAudio.Play();
                    SetUI(false);
                    EKeyOpen.SetActive(false);
                }
            }
            if (currentMashTimer >= totalMashTimer && buttonMashRequirement < totalMashRequirement)
            {
                pushing = false;
                buttonMashRequirement = 0;
                currentMashTimer = 0;
                Bar1.SetActive(false);
                Bar2.SetActive(false);
                Bar1Fill.enabled = false;
                Bar2Fill.enabled = false;
                //DeactivateBar

            }
        }

    }
    public void SetUI(bool Value)
    {
        EKeyPress.SetActive(Value);

        Bar1.SetActive(Value);
        Bar2.SetActive(Value);
        Bar1Fill.enabled = Value;
        Bar2Fill.enabled = Value;

    }


}

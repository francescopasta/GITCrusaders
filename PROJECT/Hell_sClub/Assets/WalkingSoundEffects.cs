using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundEffects : MonoBehaviour
{
    public PlayerScript playerScript;
    public AudioSource footstepsAudio; // Changed to AudioSource for better control
    public float pitchMin = 0.8f;
    public float pitchMax = 1.2f;
    public bool playingSound;

    // Update is called once per frame
    void Update()
    {
        // Use Update instead of FixedUpdate for audio triggering
        if (playerScript.isWalking && playerScript.Grounded && !playingSound)
        {
            StartCoroutine(PlayAudio());
        }
    }

    public IEnumerator PlayAudio()
    {
        playingSound = true;

        // Randomize pitch for variety
        footstepsAudio.pitch = Random.Range(pitchMin, pitchMax);

        // Play the sound
        footstepsAudio.Play();

        // Wait for the clip duration before allowing the next sound
        if (!playerScript.isRunning)
        {
            yield return new WaitForSeconds(footstepsAudio.clip.length * 2);

        }
        else
        {
            yield return new WaitForSeconds(footstepsAudio.clip.length * 1.2f);

        }
        playingSound = false;
    }
}

using UnityEngine;
public class Footsteps : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Check if player is moving
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Play sound
            }
        }
        else
        {
            audioSource.Stop(); // Stop sound when stopped
        }
    }
}
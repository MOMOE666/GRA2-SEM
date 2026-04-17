using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip barrel;
    AudioSource audio;
    // Use this for initialization
    void Start()
    {

        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
            audio.PlayOneShot(barrel, 1.0f);


    }
}
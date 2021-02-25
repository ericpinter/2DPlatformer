using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, grabFlagSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        grabFlagSound = Resources.Load<AudioClip>("GrabFlag");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        if (clip == "Jump")
        {
            audioSrc.PlayOneShot(jumpSound);
        }
        if (clip == "GrabFlag")
        {
            audioSrc.PlayOneShot(grabFlagSound);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, grabFlagSound;
    public static AudioSource audioSrc;


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

    public static void PlaySound(string clip, float time)
    {

        AudioClip c = jumpSound;
        if (clip == "Jump")
        {
            c = jumpSound;
        }
        else if (clip == "GrabFlag")
        {
            c = grabFlagSound;
        }
        if (time>0) audioSrc.pitch = c.length / time;
        audioSrc.PlayOneShot(c);
        
    }
}

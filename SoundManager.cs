using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, FireSound, JumpSound, deadsound, flysound, bgsound, Explode, CoinColected, kiking, Punch,click;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        FireSound = Resources.Load<AudioClip>("FireSound");
        JumpSound = Resources.Load<AudioClip>("jump");
        deadsound = Resources.Load<AudioClip>("deadsound");
        flysound = Resources.Load<AudioClip>("flysound");
        bgsound = Resources.Load<AudioClip>("bgsound");
        Explode = Resources.Load<AudioClip>("Explode");
        CoinColected = Resources.Load<AudioClip>("CoinColected");
        kiking =  Resources.Load<AudioClip>("kik");
        Punch = Resources.Load<AudioClip>("punch");
        click = Resources.Load<AudioClip>("Click");

        audioSrc = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySounds(string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "playerhit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "dead":
                audioSrc.PlayOneShot(deadsound);
                break;
            case "flysound":
                audioSrc.PlayOneShot(flysound);
                break;
            case "bgsound":
                audioSrc.PlayOneShot(bgsound);
                
                break;
            case "Explode":
                audioSrc.PlayOneShot(Explode);

                break;
            case "CoinColected":
               audioSrc.PlayOneShot(CoinColected);

                break;
            case "kik":
                audioSrc.PlayOneShot(kiking);

                break;
            case "punch":
                audioSrc.PlayOneShot(Punch);

                break;
            case "Click":
                audioSrc.PlayOneShot(click);

                break;
        }
    }
}

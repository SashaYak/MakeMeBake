using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource SFXSource;

    public AudioClip confirmSound;
    public AudioClip backSound;
    public AudioClip takeCardSoundSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    private void Awake()
    {
        Instance = this;
    }

    public static void PlayConfirmSound() 
    {
        Instance.SFXSource.PlayOneShot(Instance.confirmSound);
    }

    public static void PlayBackSound()
    {
        Instance.SFXSource.PlayOneShot(Instance.backSound);
    }
    public static void PlayTakeCardSound()
    {
        Instance.SFXSource.PlayOneShot(Instance.takeCardSoundSound);
    }
    public static void PlayloseSound()
    {
        Instance.SFXSource.PlayOneShot(Instance.loseSound);
    }
    public static void PlayWinSound()
    {
        Instance.SFXSource.PlayOneShot(Instance.winSound);
    }
}

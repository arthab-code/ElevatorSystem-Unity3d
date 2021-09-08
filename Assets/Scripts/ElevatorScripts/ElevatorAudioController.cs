using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAudioController : MonoBehaviour
{
    public AudioSource mAudioSource;
    public AudioClip mDoorAction;
    public AudioClip mElevatorBell;
    public AudioClip mElevatorRide;

    public void PlaySFX(AudioClip audioClip)
    {
        if (mAudioSource.isPlaying)
            return;

        mAudioSource.clip = audioClip;
        mAudioSource.Play();
    }

    public void StopSFX()
    {
        mAudioSource.Stop();
    }
}

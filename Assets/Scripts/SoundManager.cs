using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    [SerializeField] private float backGroundVolume = 0.2f;
    [SerializeField] private float soundEffectsVolume = 1.0f;
    private void Start()
    {
        audioSource.PlayOneShot(audioClips[0], backGroundVolume);
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(audioClips[index], soundEffectsVolume);
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}

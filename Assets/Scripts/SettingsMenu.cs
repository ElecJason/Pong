using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SettingsMenu : MonoBehaviour
{   
    [Header("Unity Events")]
    [SerializeField] private UnityEvent<int> playMusic = new UnityEvent<int>();
    [SerializeField] private UnityEvent stopMusic = new UnityEvent();

    [Header("Settings Objects")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] private bool FullScreen;

    private Resolution[] resolutions;
    
    private void Start()
    {
        resolutions =  Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        stopMusic.Invoke();
        playMusic.Invoke(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Method to set the volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Method to reset player preferences
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player preferences reset.");
    }
}

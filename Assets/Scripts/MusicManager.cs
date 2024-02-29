using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> musicTracks; // List of music tracks

    private AudioSource audioSource; // Reference to the AudioSource component

    private int currentTrackIndex = -1; // Index of the currently playing track

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on the MusicManager GameObject.");
            return;
        }

        // Check if there are any music tracks assigned
        if (musicTracks == null || musicTracks.Count == 0)
        {
            Debug.LogWarning("No music tracks assigned to the MusicManager.");
            return;
        }

        // Start playing a random track from the list
        PlayRandomTrack();
    }

    void Update()
    {
        // Check if the current track has finished playing
        if (!audioSource.isPlaying)
        {
            // Play the next track in the list
            PlayNextTrack();
        }
    }

    // Play a random track from the list
    private void PlayRandomTrack()
    {
        int randomIndex = Random.Range(0, musicTracks.Count);
        audioSource.clip = musicTracks[randomIndex];
        audioSource.Play();
        currentTrackIndex = randomIndex;
    }

    // Play the next track in the list
    private void PlayNextTrack()
    {
        // Increment the current track index
        currentTrackIndex++;

        // If the index exceeds the number of tracks, loop back to the beginning
        if (currentTrackIndex >= musicTracks.Count)
        {
            currentTrackIndex = 0;
        }

        // Set and play the next track
        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();
    }
}

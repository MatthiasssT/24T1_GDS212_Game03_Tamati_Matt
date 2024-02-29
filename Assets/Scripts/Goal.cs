using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Scoreboard scoreboard; // Reference to the Scoreboard script
    public AudioSource goalSFX; // Reference to the AudioSource for goal sound effect
    public GameObject particleEffectPrefab; // Reference to the particle effect prefab

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the GroundCheck component on the collided player object
            GroundCheck groundCheck = other.GetComponent<GroundCheck>();
            if (groundCheck != null)
            {
                groundCheck.enabled = false;
            }

            if (scoreboard != null)
            {
                scoreboard.GoalAchieved();

                // Check if the goal sound effect and AudioSource are assigned
                if (goalSFX != null)
                {
                    // Play the goal sound effect once
                    goalSFX.PlayOneShot(goalSFX.clip);
                }
                else
                {
                    Debug.LogWarning("Goal sound effect reference not set in Goal script!");
                }

                Handheld.Vibrate();

                // Instantiate the particle effect as a child of the current object with an offset
                if (particleEffectPrefab != null)
                {
                    GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
                    // Play the particle effect
                    particleEffect.GetComponent<ParticleSystem>().Play();
                    // Destroy the particle effect after its duration
                    Destroy(particleEffect, particleEffect.GetComponent<ParticleSystem>().main.duration);
                }
                else
                {
                    Debug.LogWarning("Particle effect prefab reference not set in Goal script!");
                }
            }
            else
            {
                Debug.LogWarning("Scoreboard reference not set in Goal script!");
            }
        }
    }
}

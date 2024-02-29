using System.Collections;
using UnityEngine;

public class BallCollisionFX : MonoBehaviour
{
    [SerializeField] AudioClip hitSFX; // Sound effect played on collision with level
    [SerializeField] AudioClip deadSFX; // Sound effect played on ball destruction
    [SerializeField] GameObject particleEffectPrefab; // Prefab of the particle effect

    private AudioSource audioSource;
    private Collider parentCollider; // Collider of the parent GameObject

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on the same GameObject as BallCollisionFX script.");
        }

        // Get the collider of the parent GameObject
        parentCollider = transform.parent.GetComponent<Collider>();
        if (parentCollider == null)
        {
            Debug.LogWarning("Collider component not found on the parent GameObject.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Level" using the parent collider
        if (collision.collider == parentCollider && collision.gameObject.CompareTag("Level"))
        {
            // Play the hit sound effect
            if (audioSource != null && hitSFX != null)
            {
                audioSource.PlayOneShot(hitSFX);
            }
            else
            {
                Debug.LogWarning("AudioSource or hitSFX not assigned in BallCollisionFX script.");
            }
        }
    }

    // Method to be called when the ball is thrown
    public void BallThrown()
    {
        // Start the coroutine to handle destruction after a delay
        StartCoroutine(Destruct());
    }

    IEnumerator Destruct()
    {
        // Wait for 20 seconds
        yield return new WaitForSeconds(5f);

        // Spawn the particle effect prefab
        if (particleEffectPrefab != null)
        {
            GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            // Deactivate the parent object's renderer
            if (transform.parent.GetComponent<Renderer>() != null)
            {
                transform.parent.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                Debug.LogWarning("Renderer component not found on the parent GameObject.");
            }
            // Play the dead sound effect
            if (audioSource != null && deadSFX != null)
            {
                audioSource.PlayOneShot(deadSFX);
            }
            else
            {
                Debug.LogWarning("AudioSource or deadSFX not assigned in BallCollisionFX script.");
            }

            // Wait for the particle effect to finish playing
            yield return new WaitForSeconds(particleEffect.GetComponent<ParticleSystem>().main.duration);

            // Destroy the parent object (this ball) and the particle effect
            Destroy(particleEffect);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Debug.LogWarning("Particle effect prefab not assigned in BallCollisionFX script.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // Reference to the ball prefab

    private bool isPlayerColliding = false;

    void Start()
    {
        SpawnBall(); // Spawn a ball when the game starts
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerColliding = false;
            Invoke("SpawnBall", 1f); // Invoke SpawnBall after 1 second
        }
    }

    private void SpawnBall()
    {
        if (!isPlayerColliding)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }
}

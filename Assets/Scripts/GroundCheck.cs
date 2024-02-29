using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Scoreboard scoreboard; // Reference to the Scoreboard script
    public LayerMask groundLayer; // Ground layer mask

    private bool hasCollided = false; // Flag to track if collision has already occurred

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object on the ground layer and if it hasn't already collided
        if (groundLayer == (groundLayer | (1 << collision.gameObject.layer)) && !hasCollided)
        {
            Debug.Log("Player collided with ground!");
            hasCollided = true; // Set the flag to true to prevent multiple calls
            if (scoreboard != null)
            {
                scoreboard.GoalLost();
                Debug.Log("Goal lost! Current score: " + scoreboard.currentScore);
            }
            else
            {
                Debug.LogWarning("Scoreboard reference not set in GroundCheck script!");
            }
        }
    }
}

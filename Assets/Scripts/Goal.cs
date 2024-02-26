using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Scoreboard scoreboard; // Reference to the Scoreboard script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scoreboard != null)
            {
                scoreboard.GoalAchieved();
            }
            else
            {
                Debug.LogWarning("Scoreboard reference not set in GoalTrigger script!");
            }
        }
    }
}

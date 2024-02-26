using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TextMeshPro text element for displaying the score
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    // Method to incrementally increase the score
    public void GoalAchieved()
    {
        score++;
        UpdateScoreText();
    }

    // Method to reset the score to 0
    public void GoalLost()
    {
        score = 0;
        UpdateScoreText();
    }

    // Update the TextMeshPro text to display the current score
    void UpdateScoreText()
    {
        scoreText.text = score.ToString() + "x";
    }
}
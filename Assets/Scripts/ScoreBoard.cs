using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TextMeshPro text element for displaying the score
    public TMP_Text highScoreText;
    public int currentScore = 0;
    public int highScore = 0; // New variable for high score

    void Start()
    {
        // Load high score from player prefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    // Method to incrementally increase the score
    public void GoalAchieved()
    {
        currentScore++;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // Save high score to player prefs
            Debug.Log("New high score: " + highScore);
            UpdateHighScoreText();
        }
        UpdateScoreText();
    }

    // Method to reset the score to 0
    public void GoalLost()
    {
        Debug.Log(currentScore);
        currentScore = 0;
        UpdateScoreText();
        Debug.Log(currentScore);
        Debug.Log("Score reset to 0");
    }

    // Update the TextMeshPro text to display the current score
    void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString() + "x";
    }

    // Update the TextMeshPro text to display the high score
    void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}

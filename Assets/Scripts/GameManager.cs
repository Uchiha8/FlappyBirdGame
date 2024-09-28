using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player; 
    
    public Text scoreText; 
    public GameObject playButton;
    public GameObject gameOver
   private int score = 0; // Initialize to 0 for clarity

    // Optional: To keep track of game state
    private bool isGameOver = false;


    private void Awake()
    {
        Application.targetFrameRate = 60; // Set the frame rate to 60
        Pause(); // Pause the game on start
    }

    private void Play()

    {
        score = 0; // Reset the score
        scoreText.text = score.ToString(); // Update the UI text

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f; // Resume the game
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>(); // Find all the pipes in the scene
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject); // Destroy all the pipes
        }
    }

    private void Pause()
    {
        // Optional: Pause the game
        Time.timeScale = 0f;
        player.enabled = false;
    }

    void Start()
    {
        // Optional: Initialize game state
        score = 0; 
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause(); // Pause the game
    }

    public void IncrementScore()
    {
        if (!isGameOver) // Only increment if the game is not over
        {
            score++;
            scoreText.text = score.ToString(); // Update the UI text
        }
    }

    // Optional: Method to get the current score
    public int GetScore()
    {
        return score;
    }
}

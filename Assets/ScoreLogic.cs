using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreLogic : MonoBehaviour
{
    public int PlayerScore;
    public Text ScoreText;
    public int HighestScore;
    public Text HighScore; // Text to display the high score
    public GameObject GameOverScreen;
    public SharpBird Flappy;
    public GameObject TitleScreen;
    
    public bool GameStarted ; // Flag to check if the game has started

    void Start()
    {
        HighestScore = PlayerPrefs.GetInt("HighScore", 0); // Get the high score from PlayerPrefs, default to 0 if not set
        HighScore.text = HighestScore.ToString(); // Update the high score text
        TitleScreen.SetActive(true); // Show the title screen at the start
        GameOverScreen.SetActive(false);
        GameStarted = false; // Initialize the game started flag
    }

    [ContextMenu("Increase Score")] // only works if addScore has no parameters
    public void addScore(int scoreToAdd)
    {
         PlayerScore += scoreToAdd;
        ScoreText.text = PlayerScore.ToString(); 
        if (PlayerScore > HighestScore)
        {
            HighestScore = PlayerScore; // Update the high score if the current score is higher
            HighScore.text = HighestScore.ToString(); // Update the high score text
            PlayerPrefs.SetInt("HighScore", HighestScore); // Save new high score
            PlayerPrefs.Save(); // optional but good practice
        }
    }

    public void RestartGame()
    {
        GameOverScreen.SetActive(false); // Hide the game over screen
        StartGame(); // Restart the game by calling StartGame method
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        //Time.timeScale = 0; // Pause the game
    }

    public void TitleScene()
    {
        GameOverScreen.SetActive(false);
        PlayerScore = 0; // Reset the score 
        ScoreText.text = PlayerScore.ToString(); // Update the score text
        TitleScreen.SetActive(true);
    }

    public void StartGame()
    {
        TitleScreen.SetActive(false);
        Flappy.gameObject.SetActive(true); // Activate the bird
        Flappy.BirdIsAlive = true; // Reset the bird's state
        GameStarted = true;
        PlayerScore = 0; // Reset the score 
        ScoreText.text = PlayerScore.ToString(); // Update the score text
        // SoundManager.gameObject.SetActive(true); // Activate the sound manager
        Flappy.RigiidBodyy.gravityScale = 3.6f; // Enable gravity for the bird
        Flappy.gameObject.transform.position = new Vector3(0, 0, 0); // Reset bird position
        Flappy.transform.rotation = Quaternion.identity;
        Flappy.RigiidBodyy.linearVelocity = Vector2.zero;
        Flappy.RigiidBodyy.angularVelocity = 0f; // Reset the bird's velocity and angular velocity

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
        // Debug.Log("Game has been closed"); // Log message for debugging
    }


}
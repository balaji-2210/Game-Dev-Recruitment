using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject playButton;
    public GameObject menuButton;
    public int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);
        menuButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        AudioListener.pause = false;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        AudioListener.pause = true;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        menuButton.SetActive(true);

        Pause();
    }

    public void MenuAudio()
    {
        AudioListener.pause = false;
    }
}

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    public float targetFallMultiplier = 1f;
    public float fallIncreaseSpeed = 0.05f;

    public static GameManager Instance;

    public float fallSpeedMultiplier = 1f;

    public int lives = 3;
    public GameObject[] hearts;

    void Awake()
    {
        Instance = this;
        UpdateHearts();

    }

    public void LoseLife()
    {
        lives--;
        UpdateHearts();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }


    public GameObject gameOverPanel;
    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlayGameOver();

        finalScoreText.text = "Score: " + ScoreManager.Instance.score;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    void Update()
    {
        fallSpeedMultiplier = Mathf.Lerp(
            fallSpeedMultiplier,
            targetFallMultiplier,
            fallIncreaseSpeed * Time.deltaTime
        );
    }


}

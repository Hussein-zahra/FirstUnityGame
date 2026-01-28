using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int score = 0;
    public int scoreToWin = 50;

    public Text scoreText;
    public string nextSceneName = "MobileDevicesDemo";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if (score >= scoreToWin)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isGameOver = false;

    [Header("UI")]
    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI bestScoreText;

    [Header("Score")]
    [SerializeField]
    Transform player;

    [SerializeField]
    float scoreMultiplier = 1f;
    private int bestScore;

    [Header("References")]
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    ObstacleSpawner spawner;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(Restart);

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score: " + bestScore;
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        int score = Mathf.FloorToInt(player.position.z * scoreMultiplier);
        scoreText.text = $"Score: {score}";

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
            bestScoreText.text = $"Best: {bestScore}";
        }
    }

    public void GameOver()
    {
        if (isGameOver)
            return;
        isGameOver = true;
        playerController.enabled = false;
        spawner.enabled = false;
        Time.timeScale = 0f;
        StartCoroutine(ShowGameOverPanel());
    }

    private IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSecondsRealtime(1f);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

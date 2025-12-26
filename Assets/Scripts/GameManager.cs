using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isGameOver = false;

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
    }

    // Update is called once per frame
    void Update() { }

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

using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    int currentLives = 0;

    private void Awake()
    {
        if (FindObjectsOfType<LevelHandler>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        currentLives = playerLives;
        livesText.SetText(playerLives.ToString());
        scoreText.SetText(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleHit()
    {
        currentLives--;
        livesText.SetText(playerLives.ToString());
        if (currentLives <= 0) { HandleDeath(); }
    }

    private void HandleDeath()
    {
        gameOverText.gameObject.SetActive(true);
        Destroy(FindObjectOfType<PlayerMovement>().gameObject);
        Debug.Log("Game Over");
    }
    public void AddScore(int addedScore)
    {
        score += addedScore;
        scoreText.SetText(score.ToString());
    }
}

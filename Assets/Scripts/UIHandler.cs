using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gameOverText;
    LevelHandler levelHandler;
    // Start is called before the first frame update
    void Start()
    {
        levelHandler = FindObjectOfType<LevelHandler>();
        gameOverText.gameObject.SetActive(false);
        livesText.SetText(levelHandler.GetCurrentLives().ToString());
        scoreText.SetText(levelHandler.GetScore().ToString());
    }
    
    public void UpdateScore()
    {
        scoreText.SetText(levelHandler.GetScore().ToString());        
    }
    public void UpdateLives()
    {
        livesText.SetText(levelHandler.GetCurrentLives().ToString());
    }

    public void ShowGameOverUI()
    {
        gameOverText.gameObject.SetActive(true);
    }
}

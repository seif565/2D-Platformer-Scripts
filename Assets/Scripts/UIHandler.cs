using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button playAgainButton;
    [SerializeField] Button mainMenuButton;
    LevelHandler levelHandler;
    // Start is called before the first frame update
    void Start()
    {
        levelHandler = FindObjectOfType<LevelHandler>();
        gameOverText.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);
        scoreText.SetText(levelHandler.GetScore().ToString());
        mainMenuButton.gameObject.SetActive(false);        
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
        playAgainButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }
}

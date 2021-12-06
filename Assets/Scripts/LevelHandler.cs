using UnityEngine;

public class LevelHandler : MonoBehaviour
{    
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    UIHandler levelUI;

    int currentLives = 0;

    // Singleton Patterm
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
        currentLives = playerLives;
        levelUI = FindObjectOfType<UIHandler>();
        levelUI.UpdateLives();
    }

    // Decreases lives and checks if no  lives are left
    public void HandleHit()
    {
        Debug.Log("Hit Handled");
        currentLives--;
        levelUI.UpdateLives();
        if (currentLives <= 0) { HandleDeath(); }
    }

    // Ends game if no lives remain.
    public void HandleDeath()
    {
        currentLives = 0;
        levelUI.UpdateLives();
        Destroy(FindObjectOfType<PlayerMovement>().gameObject);
        levelUI.ShowGameOverUI();
    }

    // Adds points on collecting coins
    public void AddScore(int addedScore)
    {
        score += addedScore;
        levelUI.UpdateScore();
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }

    public int GetScore()
    {
        return score;
    }
}
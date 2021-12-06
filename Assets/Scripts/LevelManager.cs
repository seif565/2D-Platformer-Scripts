using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentLevel;    
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(SceneManager.sceneCountInBuildSettings);        
    }

    private void Update()
    {        
    }

    public void LoadNextLevel()
    {
        if (currentLevel == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("Fizz");
            Destroy(FindObjectOfType<LevelHandler>().gameObject);
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentLevel + 1);
        }
    }
}

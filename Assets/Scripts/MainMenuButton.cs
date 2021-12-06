using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{    
    int buttonIndex = 0;        
    public void SetButtonIndex(int index)
    {
        buttonIndex = index;
    }
    public bool IsSelected { get; set; }

    private void Update()
    {
        if(IsSelected == true && Input.GetKeyDown(KeyCode.Return))
        {
            switch (buttonIndex)
            {
                case 0:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    return;
                case 1:
                    Debug.Log("Settings Menu Loaded");
                    return;
                default:
                    Debug.Log("Application Terminated");
                    Application.Quit();
                    break;
            }
        }
    }

}

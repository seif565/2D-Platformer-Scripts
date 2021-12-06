using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button [] menuButtons;
    [SerializeField] Animator [] buttonAnimators;

    int selectedButtonIndex = 0;
    bool buttonDown = false;
    float buttonInput;

    private void Start()
    {
        menuButtons[0].GetComponent<MainMenuButton>().IsSelected = true;
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].GetComponent<MainMenuButton>().SetButtonIndex(i);
        }
    }
    private void Update()
    {
        buttonInput = Input.GetAxisRaw("Vertical");
        for( int i = 0; i != menuButtons.Length; i ++)
        {
            if(i == selectedButtonIndex)
            {
                buttonAnimators[i].SetBool("isSelected", true);
            }

            else
            {
                buttonAnimators[i].SetBool("isSelected", false);
            }
        }

                
        // Menu navigation handling
        if (buttonInput != 0 && !buttonDown)
        {
            if (-buttonInput + selectedButtonIndex < 0)
            {
                selectedButtonIndex = menuButtons.Length - 1;                
            }

            else if (-buttonInput + selectedButtonIndex == menuButtons.Length)
            {
                selectedButtonIndex = 0;
            }
            else
            {
                selectedButtonIndex += (int)-buttonInput;
            }
            SetSelected();
            buttonDown = true;            
        }
        else if (buttonInput == 0) { buttonDown = false; }
    }

    public void SetSelected()
    {
        for (int i = 0; i != menuButtons.Length; i++)
        {
            if (i == selectedButtonIndex)
            {
                buttonAnimators[i].SetBool("isSelected", true);
                buttonAnimators[i].GetComponent<MainMenuButton>().IsSelected = true;
            }

            else
            {
                buttonAnimators[i].SetBool("isSelected", false);
                buttonAnimators[i].GetComponent<MainMenuButton>().IsSelected = false;
            }
        }
    }
}

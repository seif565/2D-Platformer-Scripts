using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] int score = 0;

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
        gameOverCanvas.gameObject.SetActive(false);
        currentLives = playerLives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleHit()
    {
        currentLives--;
        Debug.Log(currentLives);
        if (currentLives <= 0) { HandleDeath(); }
    }

    private void HandleDeath()
    {
        gameOverCanvas.gameObject.SetActive(true);
        Destroy(FindObjectOfType<PlayerMovement>().gameObject);
        Debug.Log("Game Over");
    }
    public void AddScore(int addedScore)
    {
        score += addedScore;
    }
}

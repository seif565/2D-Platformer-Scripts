using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Loads next level if player enters the door trigger.
        if (collision.GetComponent<PlayerMovement>())
        {
            FindObjectOfType<LevelManager>().LoadNextLevel();
        }

    }
}
